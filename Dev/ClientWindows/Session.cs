using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientWindows
{
    class Session
    {
        public Session()
        {


        }

        public String tryAuth(String user, String password)
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
                    (object)user,
                    (object)password
                };

                MSG msgReturn = proxy.dispatching(msg);

                string user_token = (string)msgReturn.data[0];

                Console.WriteLine(
                    //msgReturn.op_statut
                    user_token
                    );


                return user_token;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "error";
            }
        }
    }
}
