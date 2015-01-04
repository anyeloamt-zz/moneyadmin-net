using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyAdmin.Data.Entities;

namespace MoneyAdmin.Data
{
    public partial class Database : DbContext
    {
        public Database() :
            base(ConfigurationManager.ConnectionStrings["MoneyAdminConn"].ConnectionString)
        {

        }

        public Database(string connectionString) :
            base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasRequired(c => c.Creator)
                .WithMany(u => u.CategoriesCreated)
                .HasForeignKey(c => c.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasRequired(c => c.Modifier)
                .WithMany(u => u.CategoriesModified)
                .HasForeignKey(c => c.UpdatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasRequired(t => t.Creator)
                .WithMany(u => u.TransactionsCreated)
                .HasForeignKey(t => t.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transaction>()
                .HasRequired(t => t.Modifier)
                .WithMany(u => u.TransactionsModified)
                .HasForeignKey(t => t.UpdatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wallet>()
                .HasRequired(w => w.Creator)
                .WithMany(u => u.WalletsCreated)
                .HasForeignKey(w => w.CreatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Wallet>()
                .HasRequired(w => w.Modifier)
                .WithMany(u => u.WalletsModified)
                .HasForeignKey(w => w.UpdatedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); 
        }

        public override int SaveChanges()
        {
            // TODO: Add audit fields before save
            return base.SaveChanges();
        }
    }
}
