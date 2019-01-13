using System.Threading.Tasks;

namespace SriSloka.Api.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
