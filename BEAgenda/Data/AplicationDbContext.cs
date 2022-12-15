using BEAgenda.Entities;
using Microsoft.EntityFrameworkCore;

namespace BEAgenda.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
