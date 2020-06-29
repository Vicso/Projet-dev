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
        string user_token = "";

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

                user_token = (string)msgReturn.data[0];

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

        public bool sendFiles(String fileContent)
        {
            EndpointAddress ep = new EndpointAddress("http://localhost:8010/Server/services");

            try
            {
                CommonLib.i_Dispatching proxy = ChannelFactory<CommonLib.i_Dispatching>.CreateChannel(new BasicHttpBinding() {
                    MaxBufferSize = int.MaxValue,
                    MaxReceivedMessageSize = int.MaxValue, 
                    ReceiveTimeout = new TimeSpan(0, 10, 0),
                    SendTimeout = new TimeSpan(0, 10, 0)
                } , ep);

                MSG msg = new CommonLib.MSG();

                msg.op_name = "decryptFile";
                msg.op_infos = "request to decrypt file with user_token";
                msg.op_statut = "pending";
                msg.op_version = "1.0";
                msg.app_tocken = "LICENSE_XXX";
                msg.app_version = "1.0";
                msg.data = new object[2] {
                    (object)user_token,
                    (object)fileContent
                };

                MSG msgReturn = proxy.dispatching(msg);

                //user_token = (string)msgReturn.data[0];

                Console.WriteLine(
                    msgReturn.op_statut
                    //user_token
                    );


                if (msgReturn.op_statut == "accepted")
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
