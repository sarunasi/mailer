using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mailer
{
	public partial class LogInForm : Form
	{
		public LogInForm()
		{
			InitializeComponent();
		}

		private void LogInForm_Load(object sender, EventArgs e)
		{

		}

		private void buttonLogIn_Click(object sender, EventArgs e)
		{
			var communicator = new Pop3Communicator(textBoxUsername.Text, textBoxPassword.Text, textBoxServer.Text, Int32.Parse(textBoxPort.Text));

			try
			{
				string answer = communicator.TryConnection();
				if (answer.StartsWith("-ERR"))
				{
					textBoxError.Text = answer.Substring(4);
					return;
				}
			}
			catch (Exception ex)
			{
				textBoxError.Text = ex.Message;
				return;
			}

			ClientForm client = new ClientForm(textBoxUsername.Text, communicator);
			client.Show();

			this.Hide();

		}

		private void textBoxUsername_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBoxPort_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBoxPassword_TextChanged(object sender, EventArgs e)
		{

		}

		private void LogInForm_FormClosed(object sender, FormClosedEventArgs e)
		{

			Application.Exit();
		}
	}
}
