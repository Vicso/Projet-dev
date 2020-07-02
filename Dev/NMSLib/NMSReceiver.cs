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
        int _id;

        IMessageConsumer _consumer;

        public NMSReceiver(IMessageConsumer consumer, int id)
        {
            _consumer = consumer;
            _id = id;
            Console.WriteLine("id is "+ _id);
        }

        /// <summary>
        /// Initialises the listener.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public NMSMessage InitialiseListener()
        {
            while (true)
            {

                

                var message = (ITextMessage)_consumer.Receive();
                if (message == null) continue;
                if (string.IsNullOrWhiteSpace(message.Text)) continue;

                var deserializedUser = new NMSMessage();
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(message.Text));
                var ser2 = new DataContractJsonSerializer(deserializedUser.GetType());
                deserializedUser = ser2.ReadObject(ms) as NMSMessage;
                ms.Close();

                //Console.WriteLine("wot" + deserializedUser.ID);

                if (deserializedUser.ID == _id)
                {
                    return deserializedUser;
                    //callback(1);
                }

                //Console.WriteLine(message.Text);
            }
        }

    }
}
