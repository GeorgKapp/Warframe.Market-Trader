using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using Warframe.Market_Infrastructure.Models;
using Warframe.Market_Infrastructure.Models.Enums;

namespace Warframe.Market_Infrastructure
{
    public class DataBaseContext : DbContext
    {
        #region Enum Class Section
        public DbSet<OrderType> OrderType { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<IconFormat> IconFormat { get; set; }
        #endregion

        #region Class Table Section
        public DbSet<Item> Item { get; set; }
        public DbSet<Translation> Translation { get; set; }
        public DbSet<Tag> Tag { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderType>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Language>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<IconFormat>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            modelBuilder.Entity<Item>()
                .HasOptional(s => s.ParentItem)
                .WithMany(s => s.ItemsInSet);

            modelBuilder.Entity<Item>()
                .Property(s => s.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
