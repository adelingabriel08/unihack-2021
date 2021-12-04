using System.Threading.Tasks;

namespace HelpYourCity.Core.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}