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
    class Pop3Communicator : IEmailCommunicator
    {
        private StreamWriter writer;
        private StreamReader reader;

        private const string Error = "-ERR";

        public Pop3Communicator()
        {

        }

        public string Connect(string server, int port)
        {
            TcpClient tcpclient = new TcpClient();
            tcpclient.Connect(server, port);

            SslStream sslstream = new SslStream(tcpclient.GetStream());

            sslstream.AuthenticateAsClient(server);

            writer = new StreamWriter(sslstream);
            reader = new StreamReader(sslstream);

            return reader.ReadLine();
        }

        public List<ReceivedMail> GetEmails()
        {
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

                return emails;

            }

        }

        public string LogIn(string username, string password)
        {
            Write("USER " + username);
            return Write("PASS " + password);
        }

        public string Quit()
        {
            return Write("QUIT");
        }

        public string Write(string content)
        {
            writer.WriteLine(content);
            writer.Flush();

            return reader.ReadLine();
        }
    }
}
