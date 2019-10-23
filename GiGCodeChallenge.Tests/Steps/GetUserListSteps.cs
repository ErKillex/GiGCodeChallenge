using GiGCodeChallenge.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using TechTalk.SpecFlow;

namespace GiGCodeChallenge.Tests.Steps
{
    [Binding]
    public class GetUserListSteps:ApiBaseSteps
    {
        private readonly string ApiPath = @"api/users";
        private IRestResponse<UserListApiResponse> Response { get; set; }


        [When(@"I send the request")]
        public void WhenISendTheRequest()
        {
            var request = new RestRequest
            {
                Resource = this.ApiPath,
                RequestFormat = DataFormat.Json, 
                Method = Method.GET
            };
            Response = RequestService.ExcecuteRequest<UserListApiResponse>(request);
        }
        
        [Then(@"the response should have the status code '(.*)' with list of users")]
        public void ThenTheResponseShouldHaveTheStatusCodeWithListOfUsers(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)Response.StatusCode);
            Assert.AreEqual(Response.Data.Users.Count, Response.Data.UserPerPage);
        }
    }
}
