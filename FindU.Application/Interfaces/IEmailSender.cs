using System.Threading.Tasks;

namespace FindU.Application.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
