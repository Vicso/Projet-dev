using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
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

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Session session = new Session();

                String user_token = session.tryAuth(textBox1.Text, textBox2.Text);

                if (user_token == "" || user_token == null)
                {
                    label4.Text = "Error : Bad Credential";
                    label4.ForeColor = Color.Red;
                }
                else
                {
                    label4.Text = "Succesfully Connected with token : " + user_token;
                    label4.ForeColor = Color.Green;
                }

            }
            else
            {
                label4.ForeColor = Color.Red;
            }

            
        }


    }
}
