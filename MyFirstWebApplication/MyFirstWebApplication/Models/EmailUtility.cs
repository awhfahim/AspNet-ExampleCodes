namespace MyFirstWebApplication.Models
{
    public class EmailUtility : IEmailUtility
    {
        public void SendEmail(string receiverEmailAddress, string subject, string body)
        {
            throw new NotImplementedException();
        }

        public void ForwardEmail(string receiverEmailAddress, string subject, string body)
        { throw new NotImplementedException(); }
    }
}
