using EventProjectSWP.Models;
using System.Threading.Tasks;

namespace EventProjectSWP.Settings
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
