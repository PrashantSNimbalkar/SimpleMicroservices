using Microsoft.EntityFrameworkCore;
using UsersSerrvice.Entities;


namespace UsersService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-8FSFFAE\SQLEXPRESS;Database=SHAURYA;Integrated Security=True;");
        }
    }
}
