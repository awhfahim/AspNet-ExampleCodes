namespace MyFirstWebApplication.Models
{
    public interface IEmailUtility
    {
        void SendEmail(string receiverEmailAddress, string subject, string body);
        void ForwardEmail(string receiverEmailAddress, string subject, string body);
    }
}
