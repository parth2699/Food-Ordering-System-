namespace OnlineFoodOrderingSystem.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using WebApplication1.DAL;

    public partial class Food_Ordering : DbContext
    {
        public Food_Ordering()
            : base("name=Food_Ordering")
        {
        }

        public virtual DbSet<Tbl_MenuCategory> Tbl_MenuCategory { get; set; }
        public virtual DbSet<tbl_MenuItem> Tbl_MenuItem { get; set; }
        public virtual DbSet<Tbl_Employee> Tbl_Employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbl_MenuCategory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_MenuItem>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tbl_MenuItem>()
                .Property(e => e.Visible)
                .IsFixedLength();

            modelBuilder.Entity<Tbl_Employee>()
                .Property(e => e.FName)
                .IsUnicode(false);

            modelBuilder.Entity<Tbl_Employee>()
                .Property(e => e.LName)
                .IsUnicode(false);
        }
    }
}
