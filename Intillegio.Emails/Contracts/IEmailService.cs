namespace Intillegio.Emails.Contracts
{
    public interface IEmailService
    {
        void Send(IEmailMessage emailMessage);
        void Callback(IEmailCallback callback);
    }
}
