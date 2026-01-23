/*
 * ApplicationDbContext.cs
 * EF Core Web App Lab - ContactsAppDahlstrom
 * 
 * Defines the Entity Framework Core database context for the application.
 * - Manages the Contacts table in the SQL database.
 * - Handles database connections and CRUD operations via EF Core.
 *
 * Author: Holly Dahlstrom
 * Date: Jan 23, 2026
 * Course: CIS174
 */

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