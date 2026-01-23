using Microsoft.EntityFrameworkCore;
using ContactsAppDahlstrom.Models;

namespace ContactsAppDahlstrom.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}