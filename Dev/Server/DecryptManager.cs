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

        public DecryptManager ()
        {

        }

        public void initDecrypt(String text)
        {

            int[] firstKey = { 65, 65, 65, 65 };  // A,A,A,A
            int[] finalKey = { 90, 90, 90, 90 };  // Z,Z,Z,Z

            NMSManager NMS = new NMSManager();

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

            List<String> Keys100 = new List<String>();

            foreach (String key in keyStringTable)
            {
                String test2 = decrypt.calcXor(text, key);

                Keys100.Add(test2);

                if (resetCount > 100)
                {
                    Console.WriteLine("... " + currentKey.ToString());
                    resetCount = 0;
                    NMS.sendMessage(Keys100);
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
