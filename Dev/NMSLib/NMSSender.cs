﻿

using Apache.NMS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;

namespace NMSLib
{
    public class NMSSender
    {
        IMessageProducer _producer;
        int _userId;

        public NMSSender(IMessageProducer producer, /*string message*/List<String> message, List<String> keys, int userId)
        {
            _producer = producer;
            _userId = userId;
            SendMessageToProcessingQueue(message, keys);
        }

        /// <summary>
        /// Sends the message to processing queue.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void SendMessageToProcessingQueue(/*string message*/List<String> message, List<String> keys)
        {
            NMSMessage t = new NMSMessage();
            t.ID = 1;
            t.data = new string[message.Count];
            t.keys = new string[keys.Count];
            t.userId = _userId;

            for (int i = 0; i < message.Count; i++)
            {
                t.data[i] = message[i];
                t.keys[i] = keys[i];
            }

            var stream1 = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(NMSMessage));

            ser.WriteObject(stream1, t);

            stream1.Position = 0;
            var sr = new StreamReader(stream1);

            byte[] json = stream1.ToArray();
            stream1.Close();

            String yop = (Encoding.UTF8.GetString(json, 0, json.Length));

            var request = _producer.CreateTextMessage(yop);
            _producer.Send(request);

            //Console.WriteLine("sent"+ t.userId);

        }

    }
}
