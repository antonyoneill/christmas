using Amazon.Lambda.APIGatewayEvents;

namespace Christmas.API.Adapter
{
    public interface IRequestValidator
    {
        public bool IsRequestValid(APIGatewayProxyRequest request);
    }
}