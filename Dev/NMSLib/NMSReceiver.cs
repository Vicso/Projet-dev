using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Text;

namespace NMSLib
{
    public class NMSReceiver
    {

        IMessageConsumer _consumer;

        public NMSReceiver(IMessageConsumer consumer)
        {
            _consumer = consumer;
        }

        /// <summary>
        /// Initialises the listener.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void InitialiseListener()
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

    }
}
