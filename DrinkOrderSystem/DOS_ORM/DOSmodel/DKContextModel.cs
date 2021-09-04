using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DOS_ORM.DOSmodel
{
    public partial class DKContextModel : DbContext
    {
        public DKContextModel()
            : base("name=DKContextModel1")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<UserOrderDetail> UserOrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.SubtotalAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<OrderList>()
                .Property(e => e.TotalPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.ToppingsUnitPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<UserAccount>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrderDetail>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<UserOrderDetail>()
                .Property(e => e.RequiredTime)
                .IsFixedLength();

            modelBuilder.Entity<UserOrderDetail>()
                .Property(e => e.UnitPrice)
                .HasPrecision(18, 0);
        }
    }
}
