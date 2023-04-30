using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Core_WebApi.Models
{
    public class user
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
