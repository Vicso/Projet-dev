using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class DBManager
    {

        public DBManager()
        {

        }

        public SqlConnection initDbConnection()
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=192.168.8.150,1433\ACER-PREDATOR-G;Initial Catalog=master;User ID=root;Password=root";

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            Console.WriteLine("Connection Open  !");

            return(cnn);
        }

        public bool db_actionConnectUser(String user, String pass)
        {
            SqlConnection cnn = initDbConnection();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT * FROM [user] WHERE [username] LIKE '"+ user + "' AND [password] LIKE '" + pass + "'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0);
            }

            dataReader.Close();
            command.Dispose();
            cnn.Close();

            if (Output != "")
            {
                Console.WriteLine("Succesfully connected " + Output);
                return true;
            }
            else
            {
                Console.WriteLine("Connection error : Bad credential");
                return false;
            }

        }

        public void db_actionStoreUserToken(String user, String user_token)
        {
            SqlConnection cnn = initDbConnection();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql;

            sql = "UPDATE [user] SET user_token = '"+ user_token + "' WHERE [username] LIKE '"+ user + "'";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            command.Dispose();
            cnn.Close();

        }

    }
}
