using System;
using System.IO;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.ComTypes;
using System.Dynamic;
using System.Globalization;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Threading;
using System.Linq;

namespace test_xor {

    // faire une boucle avec toute les clé possible ou fichier
    // puis appliqué la clé sur tout les caractère du texte
    // faire le XOR
    public class Index
    {

        static void Main(string[] args)
        {
            int i = 0;
            int j = 0;
            int encryptKey = 79;
            int[] firstKey = { 65, 65, 65, 65 };  // A,A,A,A
            int[] finalKey = { 90, 90, 90, 90 };  // Z,Z,Z,Z

            /*string decryptedtext;
            string path = @"C:\Users\helsc\Desktop\PROJETDEVPOUBELLE\test\test xor\test.txt";
            String text = System.IO.File.ReadAllText(path);*/
            Decrypt decrypt = new Decrypt();
            String text = "$25a5.a5$25";
            //String key = "AAAA";

            //decrypt.ReadText(path, text);
            List<String> keyStringTable = decrypt.GenerateKey(firstKey);


            foreach(String key in keyStringTable)
            {
                String test2 = decrypt.calcXor(text, key);
            }

            //String finalString = decrypt.calcXor(text, keyStringTable[8200]);
        }
    }
}





        
    
