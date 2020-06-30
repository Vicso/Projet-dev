using NMSLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class ReceiveMessage
    {

        NMSInit _nms;
        DecryptManager _dm;

        public ReceiveMessage(NMSInit nms, DecryptManager dm)
        {
            _nms = nms;
            _dm = dm;
        }

        public void run()
        {
            NMSReceiver nmsReceiver = new NMSReceiver(_nms.getConsumer());
            NMSMessage returnMsg = nmsReceiver.InitialiseListener();
            if (returnMsg.ID == 2)
            {
                _dm.stop = true;
                Console.WriteLine("Decrypted KEY :" + returnMsg.keys[0]);
            }
        }

    }
}
