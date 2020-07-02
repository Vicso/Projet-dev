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
        IConnection _connection;
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
            
        }

        /// <summary>
        /// Initializes the comms.
        /// </summary>
        private void InitializeComms()
        {
            const string userName = "admin";
            const string password = "admin";
            //const string uri = "tcp://90.14.165.118:61617";//activemq: --> changer pour LAN ou INTERNET
            const string uri = "tcp://localhost:61617";//activemq: --> changer pour LAN ou INTERNET
            var connecturi = new Uri(uri);
            var factory = new NMSConnectionFactory(connecturi);
            var connection = factory.CreateConnection(/*userName, password*/);
            connection.Start();
            _session = connection.CreateSession();
            var queueDestination = SessionUtil.GetDestination(_session, Queue);
            var topicDestination = SessionUtil.GetDestination(_session, Topic);
            _consumer = _session.CreateConsumer(topicDestination);
            _producer = _session.CreateProducer(topicDestination/*queueDestination*/);

            _connection = connection;
        }

        public IMessageProducer getProducer()
        {
            return _producer;
        }

        public IMessageConsumer getConsumer()
        {
            return _consumer;
        }

        public void closeSession()
        {
            _connection.Close();
            _session.Close();
            _consumer.Close();
            _producer.Close();

        }



    }
}
