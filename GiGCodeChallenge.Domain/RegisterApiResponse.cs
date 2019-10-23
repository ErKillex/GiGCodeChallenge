namespace GiGCodeChallenge.Domain
{
    public class RegisterApiResponse: LoginApiResponse
    {
        [RestSharp.Serializers.SerializeAs(Name = "id")]
        [RestSharp.Deserializers.DeserializeAs(Name = "id")]
        public int Id { get; set; }
    }
}
