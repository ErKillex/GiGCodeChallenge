namespace GiGCodeChallenge.Domain
{
    public class BaseApiResponse
    {
        [RestSharp.Serializers.SerializeAs(Name = "error")]
        [RestSharp.Deserializers.DeserializeAs(Name = "error")]
        public string ErrorMessage { get; set; }
    }
}
