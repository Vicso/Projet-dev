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
        NMSInit nms;
        DecryptManager _dm;
        String _initialMessage;
        int _id;

        public NMSManager(DecryptManager dm, String initialMessage, int id)
        {
            nms = new NMSInit();
            _dm = dm;
            _initialMessage = initialMessage;
            _id = id;
        }

        public void sendMessage(List<String> message, List<String> keys)
        {
            NMSSender nmsSender = new NMSSender(nms.getProducer(), message, keys, _id);
        }

        public void listenSuccessMessage()
        {
            ReceiveMessage rm = new ReceiveMessage(nms, _dm, _initialMessage, _id);
            new Thread(rm.run) { IsBackground = true }.Start();
        }
    }
}
