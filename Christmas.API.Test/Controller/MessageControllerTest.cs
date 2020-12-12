using System.Security.Cryptography;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using AutoFixture;
using Christmas.API.Controller;
using NUnit.Framework;

namespace Christmas.API.Test.Controller
{
    public class MessageControllerTest
    {
        [Test]
        public static void ItReturnsOK()
        {
            var controller = new MessageController();

            var request = new Fixture().Build<APIGatewayProxyRequest>().Create();
            
            var actual = controller.MessageReceived(request, null);

            Assert.That(actual.StatusCode, Is.EqualTo(200));
        }
    }
}