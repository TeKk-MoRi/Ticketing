using Domain.Models.Identity;
using Domain.Models.Ticket;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.Context
{
    public partial class TicketingContext : IdentityDbContext<ApplicationUser>
    {
        public TicketingContext(DbContextOptions<TicketingContext> options)
                : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Ticket>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<Category>()
                .HasQueryFilter(m => !m.IsDeleted);

            modelBuilder.Entity<TicketCategory>()
                .HasQueryFilter(m => !m.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
