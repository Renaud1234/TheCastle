using System.Threading.Tasks;

namespace TheCastle.Infrastructure.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string from, string to, string subject, string body);
    }
}
