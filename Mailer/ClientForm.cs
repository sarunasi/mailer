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
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailer
{
    public partial class ClientForm : Form
    {
        private EmailCommunicator email;

        public ClientForm(String username, String password, String server, String port)
        {
            InitializeComponent();

            email = new Pop3Communicator();

            Debug.WriteLine(email.Connect(server, Int32.Parse(port)));

            Debug.WriteLine(email.LogIn(username, password));



        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
