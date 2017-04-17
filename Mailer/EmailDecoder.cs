using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mailer
{

    class EmailDecoder
    {
        const string quotedPrintableEncoding = "Content-Transfer-Encoding: quoted-printable";
        const string base64Encoding = "Content-Transfer-Encoding: base64";

        public ReceivedMail Decode(string header)
        {
            var mail = new ReceivedMail();

            string[] lines = header.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string boundary = String.Empty;

            foreach (string line in lines)
            {
                if (line.Contains("Date:"))
                {
                    mail.Date = line.Substring(line.IndexOf(':') + 1);
                }
                if (line.Contains("Subject:"))
                {
                    mail.Subject = line.Substring(line.IndexOf(':') + 1).Trim();
                    if (mail.Subject.StartsWith("=?UTF-8?B?"))
                    {
                        mail.Subject = mail.Subject.Substring("=?UTF-8?B?".Length);
                        mail.Subject = mail.Subject.Remove(mail.Subject.IndexOf("?="));

                        var data = Convert.FromBase64String(mail.Subject);
                        mail.Subject = Encoding.UTF8.GetString(data);
                    }
                }
                if (line.Contains("From:"))
                {
                    string info = line.Substring(line.IndexOf(':') + 1);

                    string address = info.Substring(info.IndexOf('<') + 1, info.IndexOf('>') - info.IndexOf('<') - 1);
                    string displayName = info.Substring(0, info.IndexOf('<'));

                    mail.FromAddress = address;
                    mail.FromDisplayName = displayName;
                }
                if (line.Contains("boundary="))
                {
                    boundary = line.Substring(line.IndexOf("boundary=") + "boundary=".Length);
                }

            }

            var bodyStartIndex = header.IndexOf("Content-Type: text/html; charset=UTF-8") + "Content-Type: text/html; charset=UTF-8".Length;
            var bodyEndIndex = header.IndexOf(boundary, bodyStartIndex) - 2;

            string body = header.Substring(bodyStartIndex, bodyEndIndex - bodyStartIndex);

            if (body.IndexOf(quotedPrintableEncoding) != -1)
            {
                bodyStartIndex = body.IndexOf(quotedPrintableEncoding) + quotedPrintableEncoding.Length;
                body = body.Substring(bodyStartIndex);

                body = DecodeQuotedPrintable(body, "UTF-8");

            }

            if (body.IndexOf(base64Encoding) != -1)
            {
                bodyStartIndex = body.IndexOf(base64Encoding) + base64Encoding.Length;
                body = body.Substring(bodyStartIndex);

                byte[] data = Convert.FromBase64String(body);
                body = Encoding.UTF8.GetString(data);
            }

            mail.Body = body;


            return mail;
        }

        private static string DecodeQuotedPrintable(string input, string bodycharset)
        {
            var i = 0;
            var output = new List<byte>();
            while (i < input.Length)
            {
                if (input[i] == '=' && input[i + 1] == '\r' && input[i + 2] == '\n')
                {
                    //Skip
                    i += 3;
                }
                else if (input[i] == '=')
                {
                    string sHex = input;
                    sHex = sHex.Substring(i + 1, 2);
                    int hex = Convert.ToInt32(sHex, 16);
                    byte b = Convert.ToByte(hex);
                    output.Add(b);
                    i += 3;
                }
                else
                {
                    output.Add((byte)input[i]);
                    i++;
                }
            }


            if (String.IsNullOrEmpty(bodycharset))
                return Encoding.UTF8.GetString(output.ToArray());
            else
            {
                if (String.Compare(bodycharset, "ISO-2022-JP", true) == 0)
                    return Encoding.GetEncoding("Shift_JIS").GetString(output.ToArray());
                else
                    return Encoding.GetEncoding(bodycharset).GetString(output.ToArray());
            }

        }

    }


    
}
