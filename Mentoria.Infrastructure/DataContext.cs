using Mentoria.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Mentoria.Infrastructure
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        //Unable to create an object of type 'DataContext'.
        //For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
        public DataContext() : base()
        {

        }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Data Source=mydb.db");

            base.OnConfiguring(optionsBuilder);
        }
    }
}