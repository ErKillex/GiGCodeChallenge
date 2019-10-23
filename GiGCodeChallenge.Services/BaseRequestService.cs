using RestSharp;
using System;

namespace GiGCodeChallenge.Services
{
    public class BaseRequestService : IBaseRequestService
    {
        protected readonly Uri baseUri;

        public BaseRequestService(string baseUrl)
        {
            baseUri = new Uri(baseUrl);
        }

        public IRestResponse<T> ExcecuteRequest<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(baseUri);
            return client.Execute<T>(request);
        }

        public IRestResponse ExcecuteSimpleRequest(RestRequest request)
        {
            var client = new RestClient(baseUri);
            return client.Execute(request);
        }
    }
}
