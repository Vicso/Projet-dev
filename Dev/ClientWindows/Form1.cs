using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NMSLib;

namespace ClientWindows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=192.168.8.150,1433\ACER-PREDATOR-G;Initial Catalog=master;User ID=root;Password=root";

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            MessageBox.Show("Connection Open  !");

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

            MessageBox.Show(Output);

            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NMSInit nms = new NMSInit();
            /*while (true) ;
            {

            }*/
        }
    }
}
