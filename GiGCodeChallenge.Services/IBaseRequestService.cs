using RestSharp;

namespace GiGCodeChallenge.Services
{
    public interface IBaseRequestService
    {
        IRestResponse<T> ExcecuteRequest<T>(RestRequest request) where T : new();
        IRestResponse ExcecuteSimpleRequest(RestRequest request);
    }
}