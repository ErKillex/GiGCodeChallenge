using Confluent.Kafka;
using System;
using System.Threading;

namespace GiGCodeChallenge.Services
{
    public class KafkaConsumerService
    {
        private ConsumerConfig Config { get; set; }

        private IConsumer<Ignore, string> Consumer { get; set; }

        public KafkaConsumerService(string kafkaEndpoint, string groupId)
        {
            Config = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = kafkaEndpoint,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        public void Subscribe(string topic)
        {
            Consumer = new ConsumerBuilder<Ignore, string>(Config).Build();
            Consumer.Subscribe(topic);
        }

        public void Unsubscribe()
        {
            Consumer.Unsubscribe();
            Consumer.Close();
        }

        public string Consume(CancellationTokenSource cancellationToken)
        {
            var result = Consumer.Consume(cancellationToken.Token);
            return result.Message.Value;
            //try
            //{
            //    var result = Consumer.Consume(cancellationToken.Token);
            //    return result.Value;
            //}
            //catch (OperationCanceledException)
            //{
            //    Unsubscribe();
            //    return "Consumer Unsubscribed!";
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public string ConsumeTimeout(TimeSpan t)
        {
            var result = Consumer.Consume(t);
            return result.Message.Value;
        }
    }
}
