using System.Net;
using System.Threading.Tasks;
using System.Web;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Christmas.Command;
using Christmas.Model;
using Christmas.Usecase;

namespace Christmas.API.Controller
{
    public class MessageController
    {
        private readonly IHandleIncomingMessageUsecase _handleIncomingMessage;

        public MessageController(IHandleIncomingMessageUsecase handleIncomingMessage)
        {
            _handleIncomingMessage = handleIncomingMessage;
        }
        
        public APIGatewayProxyResponse MessageReceived(APIGatewayProxyRequest request, ILambdaContext context)
        {
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