using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace VigenereEncrypt
{
    public class VingereEncryption
    {

        public string Encrypt(object sender, string userinput, string userkey)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Declares alphabet as a char array.
            var chartest = new Regex("^[A-Za-z]");

            int keylength = userkey.Length;
            int msglength = userinput.Length;

            List<char> encryptedchar = new List<char>(); //Makes a new list for the characters to be stored in.
            List<int> encryptedlist = new List<int>(); //Makes a new list for the encrytped numbers to be stored in.
            List<int> msglist = new List<int>(); //LList will take conversion values for the message.
            List<int> keylist = new List<int>(); //List will take conversion values for the key. 

            if (chartest.IsMatch(userkey) && chartest.IsMatch(userinput)) //Builds two arrays, one for the msg and one for the key.
            {
                foreach (char a in userinput)
                {
                    int position = char.ToUpper(a) - 'A';
                    msglist.Add(position);

                }

                foreach (char a in userkey)
                {
                    int position = char.ToUpper(a) - 'A';
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
            return encryptedmsg;
        }
        

        public  string Decrypt(object sender, string userinput, string userkey)
        {
            char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(); //Declares alphabet as a char array
            var chartest = new Regex("^[A-Za-z]");

            int keylength = userkey.Length;
            int msglength = userinput.Length;

            List<char> encryptedchar = new List<char>(); //Makes a new list for the characters to be stored in.
            List<int> encryptedlist = new List<int>(); //Makes a new list for the encrytped numbers to be stored in.
            List<int> msglist = new List<int>(); //LList will take conversion values for the message.
            List<int> keylist = new List<int>(); //List will take conversion values for the key. 

            if (chartest.IsMatch(userkey) && chartest.IsMatch(userinput)) //Builds two arrays, one for the msg and one for the key.
            {
                foreach (char a in userinput)
                {
                    int position = char.ToUpper(a) - 65;
                    msglist.Add(position);
                }

                foreach (char a in userkey)
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
                    int decrypted = (nth - kj) % 26; //Actual "decryption" done here
                    if (decrypted < 0)
                    {
                        decrypted = decrypted + 26; //Checks if answer is negative, since we are decrypting. 
                    }
                    encryptedlist.Add(decrypted);
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


            string decryptedmsg = builder.ToString();
            return decryptedmsg;
        }
    }
}
