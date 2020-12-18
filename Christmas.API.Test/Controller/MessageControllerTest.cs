using System.Security.Cryptography;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AutoFixture;
using Christmas.API.Adapter;
using Christmas.API.Controller;
using Christmas.Command;
using Christmas.Usecase;
using Moq;
using NUnit.Framework;
using Twilio.Security;

namespace Christmas.API.Test.Controller
{
    public class MessageControllerTest
    {
        [Test]
        public static void ItPassesTheRequestToApplication()
        {
            var mockHandleMessageUsecase =
                new Mock<IHandleIncomingMessageUsecase>();
            var mockRequestValidator = new Mock<IRequestValidator>();

            var controller = new MessageController(mockHandleMessageUsecase.Object, mockRequestValidator.Object);

            var request = new Fixture().Build<APIGatewayProxyRequest>()
                .With(proxyRequest => proxyRequest.Body, "From=%2B44123456789&To=%2B44987654321&Body=Testing%20123")
                .Create();

            var actual = controller.MessageReceived(request, null);

            mockHandleMessageUsecase.Verify(
                x => x.Execute(It.Is<HandleIncomingMessageCommand>(command =>
                    command.IncomingMessage.From == "+44123456789" && command.IncomingMessage.To == "+44987654321" &&
                    command.IncomingMessage.Body == "Testing 123")), Times.Once());
            Assert.That(actual.StatusCode, Is.EqualTo(204));
        }

        [Test]
        public static void ItRejectsFakeRequests()
        {
            var mockHandleMessageUsecase =
                new Mock<IHandleIncomingMessageUsecase>();
            var mockRequestValidator = new Mock<IRequestValidator>();
            mockRequestValidator.Setup(x => x.IsRequestValid(It.IsAny<APIGatewayProxyRequest>())).Returns(false);
            
            var controller = new MessageController(mockHandleMessageUsecase.Object, mockRequestValidator.Object);
            
            var request = new Fixture().Build<APIGatewayProxyRequest>().Create();

            var actual = controller.MessageReceived(request, null);

            mockRequestValidator.Verify(
                x => x.IsRequestValid(It.IsAny<APIGatewayProxyRequest>()), Times.Once());
            Assert.That(actual.StatusCode, Is.EqualTo(403));
        }
    }
}