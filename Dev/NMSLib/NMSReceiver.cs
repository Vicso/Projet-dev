using Apache.NMS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
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
        public NMSMessage InitialiseListener()
        {
            while (true)
            {

                Console.WriteLine("wot");

                var message = (ITextMessage)_consumer.Receive();
                if (message == null) continue;
                if (string.IsNullOrWhiteSpace(message.Text)) continue;

                var deserializedUser = new NMSMessage();
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(message.Text));
                var ser2 = new DataContractJsonSerializer(deserializedUser.GetType());
                deserializedUser = ser2.ReadObject(ms) as NMSMessage;
                ms.Close();

                if (deserializedUser.ID == 2)
                {
                    return deserializedUser;
                    //callback(1);
                }

                //Console.WriteLine(message.Text);
            }
        }

    }
}
