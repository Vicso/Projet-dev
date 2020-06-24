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

            connetionString = @"Data Source=ACER-PREDATOR-G;Initial Catalog=master;User ID=root;Password=root";

            cnn = new SqlConnection(connetionString);
            cnn.Open();

            MessageBox.Show("Connection Open  !");
            cnn.Close();
        }

    }
}
