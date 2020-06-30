using NMSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    //public delegate void ExampleCallback(int lineCount);

    class NMSManager
    {

        NMSInit nms;
        DecryptManager _dm;

        public NMSManager(DecryptManager dm)
        {

            nms = new NMSInit();

            _dm = dm;

            //NMSSender nmsSender = new NMSSender(nms.getProducer(), "message");



        }

        public void sendMessage(/*String message*/List<String> message, List<String> keys)
        {
            NMSSender nmsSender = new NMSSender(nms.getProducer(), message, keys);
        }

        public void listenSuccessMessage()
        {
            NMSMessage msg;

            //NMSReceiver nmsReceiver = new NMSReceiver(nms.getConsumer());

            ReceiveMessage rm = new ReceiveMessage(nms, _dm);

            new Thread(rm.run) { IsBackground = true }.Start();

            /*Thread thread = new Thread(() => { msg = nmsReceiver.InitialiseListener();});
            thread.Start();
            thread.Join();*/


        }


    }
}
