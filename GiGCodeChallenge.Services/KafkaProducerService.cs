using Confluent.Kafka;
using GiGCodeChallenge.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GiGCodeChallenge.Services
{
    public class KafkaProducerService
    {
        private ProducerConfig Config { get; set; }

        public KafkaProducerService(string kafkaEndpoint)
        {
            Config = new ProducerConfig
            {
                BootstrapServers = kafkaEndpoint
            };
        }

        public string SendMessageAsync(string topic, IKafkaMessage message)
        {
            using (var producer = new ProducerBuilder<Null, string>(Config).Build())
            {
                var response = producer.ProduceAsync(topic, new Message<Null, string> { Value = message.Message() });
                return response.Result.Offset.Value.ToString();
            }
        }
    }
}
