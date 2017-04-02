using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mailer
{
    class EmailDecoder
    {

        public ReceivedMail Decode(string header)
        {
            var mail = new ReceivedMail();

            string[] lines = header.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            
            foreach(string line in lines)
            {
                if (line.Contains("Date:"))
                {
                    mail.Date = line.Substring(line.IndexOf(':') + 1);
                }
                if (line.Contains("Subject:"))
                {
                    mail.Subject = line.Substring(line.IndexOf(':') + 1);
                }
                if (line.Contains("From:"))
                {
                    string info = line.Substring(line.IndexOf(':') + 1);

                    string address = info.Substring(info.IndexOf('<') + 1, info.IndexOf('>') - info.IndexOf('<') - 1);
                    string displayName = info.Substring(0, info.IndexOf('<'));

                    mail.FromAddress = address;
                    mail.FromDisplayName = displayName;
                }
                //if (line.Contains(""))
            }

            return mail;
        }

    }
}
