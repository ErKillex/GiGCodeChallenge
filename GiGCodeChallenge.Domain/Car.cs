using Newtonsoft.Json;

namespace GiGCodeChallenge.Domain
{
    public class Car : IKafkaMessage
    {
        public string BrandName { get; set; }
        public string Model { get; set; }
        public int DoorsNumber { get; set; }
        public bool IsSportsCar { get; set; }

        public string Message()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
