using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mailer
{
    class Pop3Communicator : EmailCommunicator
    {
        private StreamWriter writer;
        private StreamReader reader;

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

        public List<string> GetEmails()
        {
            throw new NotImplementedException();
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
