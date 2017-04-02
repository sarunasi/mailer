using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailer
{
    public partial class ClientForm : Form
    {
        private List<ReceivedMail> emails = new List<ReceivedMail>();
        private DataSaver<ReceivedMail> emailSaver = new DataSaver<ReceivedMail>();

        private IEmailCommunicator email;

        public ClientForm(String username, String password, String server, String port)
        {
            InitializeComponent();

            try
            {
                emails = emailSaver.LoadDataList();
            }
            catch(FileNotFoundException ex)
            {
                
            }
            

            labelUsername.Text = username;

            email = new Pop3Communicator();

            Debug.WriteLine(email.Connect(server, Int32.Parse(port)));

            Debug.WriteLine(email.LogIn(username, password));


            UpdateEmailList();

        }

        private void UpdateEmailList()
        {

            emails.AddRange(email.GetEmails());

            try
            {
                foreach (var email in emails)
                {
                    dataGridViewEmailList.Rows.Add(email.FromDisplayName + " " + email.FromAddress, email.Subject);
                }
            }
            catch(NullReferenceException ex)
            {

            }

            

           

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            email.Quit();
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            emailSaver.SaveDataList(emails);
            email.Quit();
            Application.Exit();
        }


    }
}
