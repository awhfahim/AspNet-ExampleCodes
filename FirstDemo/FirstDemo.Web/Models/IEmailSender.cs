namespace FirstDemo.Web.Models
{
    public interface IEmailSender
    {
        void SendEmail(string receiverEmail, string subject, string body);
    }
}
