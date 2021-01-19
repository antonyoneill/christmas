using Amazon.Lambda.APIGatewayEvents;

namespace Christmas.API.Adapter
{
    public class TwilioRequestValidator : IRequestValidator
    
    {
        public bool IsRequestValid(APIGatewayProxyRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}