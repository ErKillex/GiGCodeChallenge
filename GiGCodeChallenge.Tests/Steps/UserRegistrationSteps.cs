using GiGCodeChallenge.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using TechTalk.SpecFlow;

namespace GiGCodeChallenge.Tests.Steps
{
    [Binding]
    public class UserRegistrationSteps: ApiBaseSteps
    {
        private string Email { get; set; }
        private string Password { get; set; }

        private readonly string ApiPath = @"api/register";

        private IRestResponse<RegisterApiResponse> Response { get; set; }


        [Given(@"I have entered an email address\('(.*)'\) into a registration form")]
        public void GivenIHaveEnteredValidUsernameIntoARegistrationForm(string email)
        {
            this.Email = email;
        }

        [Given(@"I have entered valid password \('(.*)'\) into a registration form")]
        public void GivenIHaveEnteredValidPasswordIntoARegistrationForm(string password)
        {
            this.Password = password;
        }

        [When(@"I send the registration values")]
        public void WhenISendTheRegistrationValues()
        {
            var request = new RestRequest
            {
                Resource = this.ApiPath,
                RequestFormat = DataFormat.Json,
                Method = Method.POST
            };
            request.AddParameter("email", this.Email);
            if (!string.IsNullOrEmpty(this.Password))
                request.AddParameter("password", this.Password);

            Response = RequestService.ExcecuteRequest<RegisterApiResponse>(request);
        }

        [Then(@"the response should have the status code '(.*)' along with a token")]
        public void ThenTheResponseShouldHaveTheStatusCodeAlongWithAToken(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)Response.StatusCode);
            Assert.IsNotNull(Response.Data.Token);
        }

        [Then(@"the response should have the status code  '(.*)' along with an error")]
        public void ThenTheResponseShouldHaveTheStatusCodeAlongWithAnError(int expectedStatusCode)
        {
            Assert.AreEqual(expectedStatusCode, (int)Response.StatusCode);
            Assert.IsNotNull(Response.Data.ErrorMessage);
        }
    }
}
