using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CommonLib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            EndpointAddress ep = new EndpointAddress("http://localhost:8010/Server/services");

            try
            {
                CommonLib.i_Dispatching proxy = ChannelFactory<CommonLib.i_Dispatching>.CreateChannel(new BasicHttpBinding(), ep);

                MSG msg = new CommonLib.MSG();

                msg.op_name = "auth";
                msg.op_infos = "auth user with credentials";
                msg.op_statut = "pending";
                msg.op_version = "1.0";
                msg.app_tocken = "LICENSE_XXX";
                msg.app_version = "1.0";
                msg.data = new object[2] {
                    (object)"user",
                    (object)"pass"
                };

                MSG msgReturn = proxy.dispatching(msg);

                Console.WriteLine(
                    msgReturn.op_statut
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
