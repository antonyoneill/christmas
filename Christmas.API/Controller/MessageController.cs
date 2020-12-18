using System.Net;
using System.Threading.Tasks;
using System.Web;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Christmas.API.Adapter;
using Christmas.Command;
using Christmas.Model;
using Christmas.Usecase;

namespace Christmas.API.Controller
{
    public class MessageController
    {
        private readonly IHandleIncomingMessageUsecase _handleIncomingMessage;
        private readonly IRequestValidator _requestValidator;

        public MessageController(IHandleIncomingMessageUsecase handleIncomingMessage, IRequestValidator requestValidator)
        {
            _handleIncomingMessage = handleIncomingMessage;
            _requestValidator = requestValidator;
        }

        public APIGatewayProxyResponse MessageReceived(APIGatewayProxyRequest request, ILambdaContext context)
        {
            if (!_requestValidator.IsRequestValid(request))
            {
                return new APIGatewayProxyResponse
                {
                    StatusCode = (int)HttpStatusCode.Forbidden
                };
            }
            
            var body = HttpUtility.ParseQueryString(request.Body);
            
            var command = new HandleIncomingMessageCommand()
            {
                IncomingMessage = new Message()
                {
                    From = body["From"],
                    Body = body["Body"],
                    To = body["To"]
                }
            };
            
            _handleIncomingMessage.Execute(command);
            
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.NoContent
            };
        }
    }
}