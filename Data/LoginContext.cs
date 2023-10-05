using Login_and_Registration.Models;
using Microsoft.EntityFrameworkCore;

namespace Login_and_Registration.Data
{
    public class LoginContext : DbContext
    {
        public LoginContext(DbContextOptions options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
