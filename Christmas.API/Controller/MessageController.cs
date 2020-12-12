using System.Net;
using System.Threading.Tasks;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;

namespace Christmas.API.Controller
{
    public class MessageController
    {
        
        public APIGatewayProxyResponse MessageReceived(APIGatewayProxyRequest request, ILambdaContext context)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = $"Thanks"
            };
        }
    }
}