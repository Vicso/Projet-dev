

using Apache.NMS;

namespace NMSLib
{
    public class NMSSender
    {
        IMessageProducer _producer;

        public NMSSender(IMessageProducer producer, string message)
        {
            _producer = producer;
            SendMessageToProcessingQueue(message);
        }

        /// <summary>
        /// Sends the message to processing queue.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void SendMessageToProcessingQueue(string message)
        {
            // Create a text message
            var request = _producer.CreateTextMessage(message);
            _producer.Send(request);
        }

    }
}
