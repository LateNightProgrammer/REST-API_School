using System.Threading.Tasks;

namespace SriSloka.Api.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
