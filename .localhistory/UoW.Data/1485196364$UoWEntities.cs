using System.Data.Entity;
using UoW.Data.Configuration;
using UoW.Model.Models;

namespace UoW.Data
{
    /// <summary>
    /// Responsible to access the database
    /// </summary>
    public class StoreEntities : DbContext
    {
        public StoreEntities() : base("StoreEntities") { }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit()
        {
            SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GadgetConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
