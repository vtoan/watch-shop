using System.Threading.Tasks;
using Application.Interfaces.Helper;

namespace Web.Services
{
    public class ConfigMail : IEmailSender
    {
        public Task Send(string subject, string body)
        {
            return null;
        }

        public Task Send(string form, string to, string subject, string body)
        {
            return null;
        }
    }
}