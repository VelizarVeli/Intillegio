namespace Intillegio.Services.Messaging.Emails.Contracts
{
    public interface IEmailService
    {
        void Send(IEmailMessage emailMessage);
    }
}
