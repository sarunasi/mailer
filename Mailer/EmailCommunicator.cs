namespace Mailer
{
    public interface EmailCommunicator
    {
        string Connect(string server, int port);

        string Write(string content);

        string LogIn(string username, string password);

        string Quit();


    }
}