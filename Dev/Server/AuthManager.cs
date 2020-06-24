using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLib;

namespace Server
{
    class AuthManager : i_Dispatching
    {
        public MSG dispatching(MSG msg)
        {

            if (msg.app_tocken == "LICENSE_XXX")
            {

            }
            else
            {
                msg.op_statut = "denied";
            }


            if (msg.op_name == "auth")
            {
                string user_token = m_auth((string)msg.data[0], (string)msg.data[1]);

                if (user_token != "")
                {
                    msg.op_statut = "accepted";
                }
                else
                {
                    msg.op_statut = "denied";
                }

                msg.data = new object[1] { (object)user_token };
            }
            else
            {

            }

            return msg;


        }

        public string m_auth(string user, string pass)
        {

            string user_token = "";

            if (user == "user" && pass == "pass")
            {
                user_token = "TOKEN_OK";
            }


            return user_token;
        }
    }
}
