namespace Application.Interfaces.Services
{
    public interface IPostService
    {
        bool GetItem(int productId, string content);
        bool AddItem(int productId, string content);
        bool UpdateItem(int productId, string content);
        bool DeleteItem(int productId);
    }
}