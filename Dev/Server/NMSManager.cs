using NMSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class NMSManager
    {

        public NMSManager()
        {

            NMSInit nms = new NMSInit();

            NMSSender nmsSender = new NMSSender(nms.getProducer(), "message");

            NMSReceiver nmsReceiver = new NMSReceiver(nms.getConsumer());

            new Thread(nmsReceiver.InitialiseListener) { IsBackground = true }.Start();

        }

    }
}
