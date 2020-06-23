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
                msg.op_name = "add";
                msg.data = new object[2] { (object)10, (object)20 };

                MSG msgReturn = proxy.dispatching(msg);
                Console.WriteLine(msgReturn.data[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
