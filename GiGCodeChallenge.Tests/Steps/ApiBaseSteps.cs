using GiGCodeChallenge.Services;
using GiGCodeChallenge.Tests.Helpers;
using TechTalk.SpecFlow;

namespace GiGCodeChallenge.Tests.Steps
{
    public class ApiBaseSteps
    {
        internal IBaseRequestService RequestService { get; set; }
//        internal IRestResponse Response { get; set; }

        private readonly Configuration Configuration = new Configuration();

        [BeforeScenario]
        public void BeforeScenario()
        {
            RequestService = new BaseRequestService(Configuration.AppSettings.ApiBaseUrl);
        }
    }
}
