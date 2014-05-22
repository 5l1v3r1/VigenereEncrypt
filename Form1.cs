using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using VigenereEncrypt;


namespace VigenereEncrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string message = textBox1.Text;
            string userkey = textBox2.Text;
            var instance = new VingereEncryption();
            textBox3.Text = instance.Encrypt(sender, message, userkey);
            
            



        }


        public string encrypt(object sender, string message, string userkey)
        {
            Char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); //Declares alphabet as a char array.
            string msg = textBox2.Text.ToString();
            string key = textBox1.Text.ToString();
            var chartest = new Regex("^[A-Za-z]");

            int keylength = key.Length;
            int msglength = msg.Length;

            List<char> encryptedchar = new List<char>(); //Makes a new list for the characters to be stored in.
            List<int> encryptedlist = new List<int>(); //Makes a new list for the encrytped numbers to be stored in.
            List<int> msglist = new List<int>(); //LList will take conversion values for the message.
            List<int> keylist = new List<int>(); //List will take conversion values for the key. 

            if (chartest.IsMatch(key) && chartest.IsMatch(msg)) //Builds two arrays, one for the msg and one for the key.
            {
                foreach (char a in msg)
                {
                    int position = char.ToUpper(a) - 65;
                    msglist.Add(position);

                }

                foreach (char a in key)
                {
                    int position = char.ToUpper(a) - 65;
                    keylist.Add(position);
                }


                //First, we find the keyword number. We loop through the list using a for-loop.
                for (int i = 0; i < msglist.Count; i++)
                {
                    int equivkey = i % keylength;
                    int kj = keylist.ElementAt(equivkey);
                    int nth = msglist.ElementAt(i);
                    int encrypted = (nth + kj) % 26;
                    encryptedlist.Add(encrypted);
                }


            }

            foreach (int a in encryptedlist)
            {
                char position = alphabet[a];
                encryptedchar.Add(position);
            }

            StringBuilder builder = new StringBuilder();
            foreach (char a in encryptedchar)
            {
                builder.Append(a);
            }


            string encryptedmsg = builder.ToString();
            textBox3.Text = encryptedmsg;
            return encryptedmsg;



            
            
 
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message = textBox5.Text;
            string userkey = textBox6.Text;
            var instance = new VingereEncryption();
            textBox4.Text = instance.Decrypt(sender, message, userkey);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
