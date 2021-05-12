using FamilyOrganizer.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyOrganizer.User
{
    public class FamilyOrganizerContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<ShoppingPlan> ShoppingPlans { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public FamilyOrganizerContext() : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Transaction>()
                .HasKey(t => t.TransactionNum);

            builder.Entity<Balance>()
                .HasKey(b => new { b.CurrentBalance, b.Date});

            builder.Entity<AppUser>()
                .HasMany(u => u.IncomingTransactions)
                .WithRequired(t => t.ToUser)
                .WillCascadeOnDelete(true);

            builder.Entity<AppUser>()
                .HasRequired(u => u.Photo)
                .WithMany(p => p.UsersWithPhoto)
                .WillCascadeOnDelete(false);

            builder.Entity<AppUser>()
                .HasMany(u => u.UserComments)
                .WithRequired(c => c.User)
                .WillCascadeOnDelete(true);
        }
    }
}
