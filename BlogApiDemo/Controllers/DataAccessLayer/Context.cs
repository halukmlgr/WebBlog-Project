using Microsoft.EntityFrameworkCore;


namespace BlogApiDemo.Controllers.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=CoreBlogApiDb;integrated security=true;");//veritabanı bağlantısı
        }
     
        public DbSet<Employee> Employees { get; set; }
    }
}
