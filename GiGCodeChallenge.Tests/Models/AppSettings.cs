using Newtonsoft.Json;

namespace GiGCodeChallenge.Tests.Models
{
    internal class AppSettings
    {
        [JsonProperty("api_base_url")]
        internal string ApiBaseUrl { get; private set; }
    }
}
