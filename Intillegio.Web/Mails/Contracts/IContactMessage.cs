namespace Intillegio.Web.Mails.Contracts
{
    public interface IContactMessage
    {
        string Name { get; set; }
        string Email { get; set; }
        string Subject { get; set; }
        string Content { get; set; }
    }
}
