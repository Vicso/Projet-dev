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

            /*if (msg.app_tocken == "LICENSE_XXX")
            {

            }
            else
            {
                msg.op_statut = "denied";
            }*/


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
            else if (msg.op_name == "decryptFile")
            {
                if (isUserTokenStillValid((string)msg.data[0]))
                {
                    msg.op_statut = "accepted";

                    NMSManager NMS = new NMSManager();

                    NMS.sendMessage((string)msg.data[1]);

                }
                else
                {
                    msg.op_statut = "denied";
                }
            }

            return msg;


        }

        public string m_auth(string user, string pass)
        {

            DBManager dbm = new DBManager();

            string user_token = "";

            if (dbm.db_actionConnectUser(user, pass))
            {
                //user_token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
                byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
                byte[] key = Guid.NewGuid().ToByteArray();
                user_token = Convert.ToBase64String(time.Concat(key).ToArray());
            }
            else
            {
                return user_token;
            }

            dbm.db_actionStoreUserToken(user, user_token);

            return user_token;
        }

        public bool isUserTokenStillValid(String user_token)
        {
            try
            {
                byte[] data = Convert.FromBase64String(user_token);
                DateTime when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
                if (when < DateTime.UtcNow.AddHours(-24))
                {
                    return false;
                }
                else
                {
                    DBManager dbm = new DBManager();

                    if (dbm.db_actionCheckValidToken(user_token))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
