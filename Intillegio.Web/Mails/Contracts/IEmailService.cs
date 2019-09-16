using Intillegio.Common.ViewModels;

namespace Intillegio.Web.Mails.Contracts
{
    public interface IEmailService
    {
        void Send(IEmailMessage emailMessage);
        void Callback(IEmailCallback callback);
    }
}
