using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Datas
{
    public class DataContext : DbContext
    {

        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=LAPTOP-KC6LB3VN;Database=LibraryDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

        }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Book> Book {  get; set; }
    public DbSet<Category> Category {  get; set; }
    }
}
