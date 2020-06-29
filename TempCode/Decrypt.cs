﻿using System;
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

namespace test_xor
{
    class Decrypt
    {

        //Boucle qui génère les clés (456976)
        public List<String> GenerateKey(int[] firstKey)
        {
            List<Array> keyIntTable = new List<Array>();
            List<String> keyStringTable = new List<String>();
            keyIntTable.Add(firstKey);
            while (true)
            {

                firstKey[3] = ++firstKey[3];

                if (firstKey[3] > 90)
                {
                    firstKey[2] = ++firstKey[2];
                    firstKey[3] = 65;

                    if (firstKey[2] > 90)
                    {
                        firstKey[1] = ++firstKey[1];
                        firstKey[2] = 65;

                        if (firstKey[1] > 90)
                        {
                            firstKey[0] = ++firstKey[0];
                            firstKey[1] = 65;
                        }
                    }
                }
                if (firstKey[0] == 90 && firstKey[1] == 90 && firstKey[2] == 90 && firstKey[3] == 90)
                {
                    break;
                }
                keyStringTable.Add(firstKey[0].ToString() + "" + firstKey[1].ToString() + "" + firstKey[2].ToString() + "" + firstKey[3].ToString());
            }
            return keyStringTable;
        }

        public string calcXor(string text, string key)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                sb.Append((char)(text[i] ^ key[(i % key.Length)]));
            }
            String decodedText = sb.ToString();

            return decodedText;
        }
    }
}
