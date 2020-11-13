using ProjetRobinF.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace ProjetRobinF.dal
{
    public class ProjetContext : DbContext
    {
        public ProjetContext() : base("ProjetContext")
        {
        }
        public DbSet<Ville> Villes { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
       
        public DbSet<Activite> Activites { get; set; }

        public DbSet<Admin> Admins { get; set; }
        public IEnumerable<object> Admin { get; internal set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}