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

		public Pop3Communicator emailCommunicator;

		private string username;

		public ClientForm(String username, Pop3Communicator emailCommunicator)
		{
			InitializeComponent();

			this.username = username;

			try
			{
				emails = emailSaver.LoadDataList(username);
			}
			catch(FileNotFoundException ex)
			{
				Debug.WriteLine(ex.Message);
			}
			

			labelUsername.Text = username;

			this.emailCommunicator = emailCommunicator;


			UpdateEmailList();

		}

		private void UpdateEmailList()
		{
			var newEmails = emailCommunicator.GetEmails();
			foreach(var email in newEmails)
			{
				emails.Insert(0, email);
			}

			dataGridViewEmailList.Rows.Clear();
			foreach (var email in emails)
			{
				dataGridViewEmailList.Rows.Add(email.FromDisplayName, email.FromAddress, email.Subject, email.Date);
			}
			dataGridViewEmailList.Refresh();

		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			emailSaver.SaveDataList(username, emails);

			var menu = new LogInForm();
			menu.Show();
			this.Hide();
		}

		private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			emailSaver.SaveDataList(username, emails);

			Application.Exit();
		}

		private void dataGridViewEmailList_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Debug.WriteLine(e.RowIndex);

			if (e.RowIndex >= 0 && e.RowIndex <= dataGridViewEmailList.RowCount)
			{
				if (this.webBrowserMailView.Document == null)
				{
					webBrowserMailView.DocumentText = emails[e.RowIndex].Body;
				}
				else
				{
					this.webBrowserMailView.Document.OpenNew(true);
					this.webBrowserMailView.Document.Write(emails[e.RowIndex].Body);
				}

				webBrowserMailView.Refresh();
			}

		}


		private void dataGridViewEmailList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete)
			{
				if (dataGridViewEmailList.SelectedCells.Count == 1)
				{
					int rowIndex = dataGridViewEmailList.SelectedCells[0].RowIndex;
					emails.RemoveAt(rowIndex);
					dataGridViewEmailList.Rows.RemoveAt(rowIndex);
					dataGridViewEmailList.Refresh();
				}

			}
		}

		private void dataGridViewEmailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			UpdateEmailList();
		}
	}
}
