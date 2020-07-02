using DecryptLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            /*string key = "cesi";
            string text = "ce projet pu la merde";

            string readText = File.ReadAllText(@"C:\Users\guill\Desktop\test.txt");
            Console.WriteLine(readText);

            Decrypt d = new Decrypt();
            string decodedText = d.calcXor(readText, key);

            Console.WriteLine(decodedText);

            using (StreamWriter writer = new StreamWriter(@"C:\Users\guill\Desktop\arabe.txt"))
            {
                writer.WriteLine(decodedText);
            }*/
            // Read a file  


            String uri = "http://192.168.8.150:8010/Server/services";
            //ServiceHost host = new ServiceHost(typeof(CommonLib.CL_Dispatching));
            ServiceHost host = new ServiceHost(typeof(AuthManager));
            try
            {
                host.AddServiceEndpoint(typeof(CommonLib.i_Dispatching), new BasicHttpBinding() {
                    MaxBufferSize = int.MaxValue,
                    MaxReceivedMessageSize = int.MaxValue,
                }, uri);
                host.Open();

                Console.WriteLine("Server listening...");

                DBManager dbm = new DBManager();

                //NMSManager NMS = new NMSManager();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();

        }
    }
}
