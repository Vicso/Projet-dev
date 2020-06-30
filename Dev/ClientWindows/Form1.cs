using CommonLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWindows
{
    public partial class Form1 : Form
    {

        String fileContent = string.Empty;
        Session session = new Session();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //try to connect with the credentials
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            button1.Enabled = false;


            if (textBox1.Text != "" && textBox2.Text != "")
            {
        
                String user_token = session.tryAuth(textBox1.Text, textBox2.Text);

                if (user_token == "" || user_token == null)
                {
                    label4.Text = "Error : Bad Credential";
                    label4.ForeColor = Color.Red;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    button1.Enabled = true;
                }
                else
                {
                    
                    label4.Text = "Succesfully Connected with token : \n" + user_token;
                    label4.ForeColor = Color.Green;

                    groupBox2.Enabled = true;
                    //groupBox1.Dispose();
                }

            }
            else
            {
                label4.ForeColor = Color.Red;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
            }

            
        }

        private void button2_Click(object sender, EventArgs e) //chose file to upload
        {

            
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            if (fileContent == null || fileContent == "")
            {
                MessageBox.Show("Please chose a valid file");
            }
            else
            {
                int lastCharIndexToShow = fileContent.Length;
                if (lastCharIndexToShow > 100)
                {
                    lastCharIndexToShow = 100;
                }


                MessageBox.Show(fileContent.Substring(0, lastCharIndexToShow), "File Content Preview at path: " + filePath, MessageBoxButtons.OK);
                //Console.WriteLine(fileContent);
                label5.Text = "File Ready !";
                label5.ForeColor = Color.Green;
                button3.Enabled = true;
            }

            

        }

        private void button3_Click(object sender, EventArgs e) //send file content to server
        {
            button2.Enabled = false;
            button3.Enabled = false;
            bool result = session.sendFiles(fileContent);
            if (result)
            {
                label6.Text = "Success !";
                label6.ForeColor = Color.Green;
            }
            else
            {
                label6.Text = "Error ! Your session is probably invalid";
                label6.ForeColor = Color.Red;
            }
        }
    }
}
