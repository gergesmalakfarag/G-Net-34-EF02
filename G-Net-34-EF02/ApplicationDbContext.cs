using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G_Net_34_EF02.Models;
using Microsoft.EntityFrameworkCore;

namespace G_Net_34_EF02
{
    internal class ApplicationDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;DataBase=G_Net_34_EF02;Trusted_Connection=true;TrustServerCertificate=true");
        }

        #region Db Sets
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Profile> Profiles { get; set; } 
        public DbSet<Badge> Badges { get; set; }
        #endregion

        #region FluentAPIS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Many-to-Many: Composite Key for Registration
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.EventId, r.AttendeeId });

            // 2. One-to-One: Organizer & Profile
            modelBuilder.Entity<Organizer>()
                .HasOne(o => o.Profile)
                .WithOne(p => p.Organizer)
                .HasForeignKey<Profile>(p => p.OrganizerId);

            // 3. Self-Referencing: Event & Sessions
            modelBuilder.Entity<Event>()
                .HasMany(e => e.Sessions)
                .WithOne(s => s.ParentEvent)
                .HasForeignKey(s => s.ParentEventId)
                .OnDelete(DeleteBehavior.Restrict); 

            // 4. Shadow Properties: Tracking
            modelBuilder.Entity<Event>().Property<DateTime>("CreatedAt").HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Event>().Property<DateTime>("LastModified");

            // 5. Owned Type: Address
            modelBuilder.Entity<Attendee>().OwnsOne(a => a.Address);
        }
        #endregion

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }
    }
}
