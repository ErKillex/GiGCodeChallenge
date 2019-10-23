namespace GiGCodeChallenge.Domain
{
    public class User
    {
        [RestSharp.Serializers.SerializeAs(Name = "id")]
        [RestSharp.Deserializers.DeserializeAs(Name = "id")]
        public int UserId { get; set; }

        [RestSharp.Serializers.SerializeAs(Name = "email")]
        [RestSharp.Deserializers.DeserializeAs(Name = "email")]
        public string Email { get; set; }

        [RestSharp.Serializers.SerializeAs(Name = "first_name")]
        [RestSharp.Deserializers.DeserializeAs(Name = "first_name")]
        public string FirstName { get; set; }

        [RestSharp.Serializers.SerializeAs(Name = "last_name")]
        [RestSharp.Deserializers.DeserializeAs(Name = "last_name")]
        public string LastName { get; set; }

        [RestSharp.Deserializers.DeserializeAs(Name = "avatar")]
        [RestSharp.Serializers.SerializeAs(Name = "avatar")]
        public string AvatarSource { get; set; }
    }
}
