using System.Threading.Tasks;
namespace Application.Interfaces.Helper
{
    public interface IEmailSender
    {
        Task Send(string subject, string body);
        Task Send(string form, string to, string subject, string body);
    }
}