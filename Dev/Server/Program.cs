using System;
using System.Collections.Generic;
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

            String uri = "http://localhost:8010/Server/services";
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
