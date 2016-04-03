namespace Zaj0222.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NorthwindModel : DbContext
    {
        public NorthwindModel()
            : base("name=NorthwindModelEntity")
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>()
                .Property(e => e.CustomerID)
                .IsFixedLength();
        }
    }
}
