using System.Collections.Generic;

namespace GiGCodeChallenge.Domain
{
    public class UserListApiResponse: BaseApiResponse
    {
        [RestSharp.Serializers.SerializeAs(Name = "page")]
        [RestSharp.Deserializers.DeserializeAs(Name = "page")]
        public int CurrentPage { get; set; }

        [RestSharp.Serializers.SerializeAs(Name = "per_page")]
        [RestSharp.Deserializers.DeserializeAs(Name = "per_page")]
        public int UserPerPage { get; set; }

        [RestSharp.Serializers.SerializeAs(Name = "total")]
        [RestSharp.Deserializers.DeserializeAs(Name = "total")]
        public int TotalUsers { get; set; }

        [RestSharp.Serializers.SerializeAs(Name = "total_pages")]
        [RestSharp.Deserializers.DeserializeAs(Name = "total_pages")]
        public int TotalPages { get; set; }

        [RestSharp.Serializers.SerializeAs(Name = "data")]
        [RestSharp.Deserializers.DeserializeAs(Name = "data")]

        public List<User> Users { get; set; }
    }
}
