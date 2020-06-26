using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.Util;

namespace NMSLib
{
    public class NMSInit
    {
        /// <summary>
        /// The producer
        /// </summary>
        private IMessageProducer _producer;
        /// <summary>
        /// The consumer
        /// </summary>
        private IMessageConsumer _consumer;
        /// <summary>
        /// The session
        /// </summary>
        private ISession _session;
        /// <summary>
        /// The queue
        /// </summary>
        private const string Queue = "queue://App.Message.Processing.Queue";
        /// <summary>
        /// The topic
        /// </summary>
        //private const string Topic = "topic://App.Message.Chat.Topic";
        private const string Topic = "topic://jms/topic/ITExpertsTopic";


        /// <summary>
        /// Gets or sets the form title.
        /// </summary>
        /// <value>
        /// The form title.
        /// </value>
        public string FormTitle { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatForm"/> class.
        /// </summary>
        public NMSInit()
        {
            InitializeComms();
            //InitializeComponent();
            (new Thread(InitialiseListener) { IsBackground = true }).Start();
        }

        /// <summary>
        /// Initialises the listener.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        private void InitialiseListener()
        {
            while (true)
            {

                Console.WriteLine("wot");

                var message = (ITextMessage)_consumer.Receive();
                if (message == null) continue;
                if (string.IsNullOrWhiteSpace(message.Text)) continue;

                Console.WriteLine(message.Text);
            }
        }

        /// <summary>
        /// Initializes the comms.
        /// </summary>
        private void InitializeComms()
        {
            const string userName = "admin";
            const string password = "admin";
            const string uri = "tcp://localhost:61617";//activemq:
            var connecturi = new Uri(uri);
            var factory = new NMSConnectionFactory(connecturi);
            var connection = factory.CreateConnection(/*userName, password*/);
            connection.Start();
            _session = connection.CreateSession();
            var queueDestination = SessionUtil.GetDestination(_session, Queue);
            var topicDestination = SessionUtil.GetDestination(_session, Topic);
            _consumer = _session.CreateConsumer(topicDestination);
            _producer = _session.CreateProducer(topicDestination/*queueDestination*/);
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
