using System.Threading.Tasks;

namespace Ecommerce_Core_WebApi.Models
{
    public interface IUserRepositoty
    {
        Task<user> addUser(user user);
        Task<user> GetUser(user user);
        Task<user> Search(user user);
    }
}
