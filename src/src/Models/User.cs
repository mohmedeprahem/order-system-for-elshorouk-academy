using Microsoft.EntityFrameworkCore;

namespace src.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
    }
}
