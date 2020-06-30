using DecryptLib;
using NMSLib;
using SendMailLib;
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
        String _initialText;
        int _id;

        public ReceiveMessage(NMSInit nms, DecryptManager dm, String initialText, int id)
        {
            _nms = nms;
            _dm = dm;
            _initialText = initialText;
            _id = id;
        }

        public void run()
        {
            NMSReceiver nmsReceiver = new NMSReceiver(_nms.getConsumer(), _id);
            NMSMessage returnMsg = nmsReceiver.InitialiseListener();
            if (returnMsg.ID == _id)
            {
                _dm.stop = true;
                Console.WriteLine("Decrypted KEY :" + returnMsg.keys[0]);
                
                Decrypt dl = new Decrypt();

                string finalFile = dl.calcXor(_initialText, returnMsg.keys[0], false);

                SendResult sr = new SendResult(finalFile, returnMsg.keys[0]);
            }
        }
    }
}
