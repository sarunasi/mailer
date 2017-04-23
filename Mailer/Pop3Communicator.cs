using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mailer
{
	public class Pop3Communicator
	{
		private StreamWriter writer;
		private StreamReader reader;
		private TcpClient tcpClient;
		private SslStream sslStream;

		private const string Error = "-ERR";


		string username, password, serverAddress;
		int port;

		private bool connected = false;

		public Pop3Communicator(string username, string password, string serverAddress, int port)
		{
			this.username = username;
			this.password = password;
			this.serverAddress = serverAddress;
			this.port = port;
		}

		public string TryConnection()
		{
			Connect();

			return LogIn();
		}

		private string Connect()
		{
			if (!connected)
			{
				tcpClient = new TcpClient();
				var result = tcpClient.BeginConnect(serverAddress, port, null, null);

				var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));
				if (!success)
				{
					throw new Exception("Couldn't connect to server");
				}

				sslStream = new SslStream(tcpClient.GetStream());

				sslStream.AuthenticateAsClient(serverAddress);

				writer = new StreamWriter(sslStream);
				reader = new StreamReader(sslStream);

				connected = true;

				return reader.ReadLine();
			}
			else
			{
				Quit();
				return Connect();
			}
			
		}

		public List<ReceivedMail> GetEmails()
		{
			Connect();

			LogIn();

			string list = Write("LIST");

			if (list.Contains(Error))
			{
				throw new IOException("Unable to get emails from the server");
			}
			else
			{

				string[] words = list.Split(' ');

				while ((list = reader.ReadLine()) != ".")
				{

				}

				int totalEmails = Int32.Parse(words[1]);
				Debug.WriteLine("Total emails: " + totalEmails);

				var emails = new List<ReceivedMail>();
				EmailDecoder decoder = new EmailDecoder();

				for (int i = 1; i <= totalEmails; i++)
				{
					Debug.WriteLine(Write("RETR " + i.ToString()));

					StringBuilder header = new StringBuilder();
					string nextLine;
					while ((nextLine = reader.ReadLine()) != ".")
					{

						header.AppendLine(nextLine);

					} 

					emails.Add(decoder.Decode(header.ToString()));

				}

				Quit();

				return emails;
			}

		}

		private string LogIn()
		{
			string answer = Write("USER " + username);
			if (answer.StartsWith(Error))
				return answer;
			else return Write("PASS " + password);
		}

		private string Quit()
		{
			string answer = Write("QUIT");
			connected = false;

			sslStream.Close();
			tcpClient.Close();
			writer.Close();
			reader.Close();
			return answer;
		}

		public string Write(string content)
		{
			writer.WriteLine(content);
			writer.Flush();

			return reader.ReadLine();
		}
	}
}
