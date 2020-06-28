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

            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=192.168.8.150,1433\ACER-PREDATOR-G;Initial Catalog=master;User ID=root;Password=root";

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            Console.WriteLine("Connection Open  !");

            db_action(cnn);


        }

        private void db_action(SqlConnection cnn)
        {
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "SELECT [username],[password] FROM [user]";

            command = new SqlCommand(sql, cnn);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
            }

            Console.WriteLine(Output);

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }


    }
}
