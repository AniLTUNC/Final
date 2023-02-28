using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class UniveraFinalProjectContext : DbContext 
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Deneme> Denemes { get; set; }
        public DbSet<Admin> Admins { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }   
    }
}
