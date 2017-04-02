using System.Collections.Generic;
using System.Net.Mail;

namespace Mailer
{
    public interface IEmailCommunicator
    {
        string Connect(string server, int port);

        string Write(string content);

        string LogIn(string username, string password);

        List<ReceivedMail> GetEmails();

        string Quit();


    }
}