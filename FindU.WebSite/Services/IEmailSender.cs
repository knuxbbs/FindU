using System.Threading.Tasks;

namespace FindU.WebSite.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
