namespace GiGCodeChallenge.Domain
{
    public class LoginApiResponse: BaseApiResponse
    {
        [RestSharp.Serializers.SerializeAs(Name = "token")]
        [RestSharp.Deserializers.DeserializeAs(Name = "token")]
        public string Token { get; set; }
    }
}
