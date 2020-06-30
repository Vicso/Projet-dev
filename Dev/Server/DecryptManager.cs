using DecryptLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class DecryptManager
    {

        public bool stop = false;

        public DecryptManager ()
        {

        }

        public void initDecrypt(String text)
        {

            int[] firstKey = { 65, 65, 65, 65 };  // A,A,A,A
            int[] finalKey = { 90, 90, 90, 90 };  // Z,Z,Z,Z

            NMSManager NMS = new NMSManager(this);

            NMS.listenSuccessMessage();

            /*string decryptedtext;
            string path = @"C:\Users\helsc\Desktop\PROJETDEVPOUBELLE\test\test xor\test.txt";
            String text = System.IO.File.ReadAllText(path);*/
            Decrypt decrypt = new Decrypt();
            //String text = "$25a5.a5$25";
            //String key = "AAAA";

            //decrypt.ReadText(path, text);
            List<String> keyStringTable = decrypt.GenerateKey(firstKey);

            int currentKey = 0;
            int resetCount = 0;

            List<String> Texts100 = new List<String>(); // Les 100 derniers texte decryptés
            List<String> Keys100 = new List<String>(); // Les 100 dernieres cles

            foreach (String key in keyStringTable)
            {

                if (stop)
                {
                    break;
                }

                String test2 = decrypt.calcXor(text, key);

                Texts100.Add(test2);
                Keys100.Add(key);

                if (key == "CESI")
                {
                    Console.WriteLine("CESI");
                }

                if (resetCount > 100)
                {
                    Console.WriteLine("... " + currentKey.ToString() + key);
                    resetCount = 0;
                    NMS.sendMessage(Texts100, Keys100);
                    Texts100.Clear();
                    Keys100.Clear();
                }


                //NMS.sendMessage(test2);

                currentKey++;
                resetCount++;






            }

            DateTime localDate = DateTime.Now;

            Console.WriteLine("DECRYPT DONE !" + localDate);

            //String finalString = decrypt.calcXor(text, keyStringTable[8200]);
        }



    }
}
