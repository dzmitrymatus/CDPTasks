using RestSharp;

namespace RestSharpExtensions
{
    public static class RestRequestExtensions
    {
        public static void AddContentToBody(this RestRequest request, string body)
        {
            RequestParameter parameter = new RequestParameter() { Value = body, Type = ParameterType.RequestBody };
            request.AddParameter(parameter);
        }
    }
}
