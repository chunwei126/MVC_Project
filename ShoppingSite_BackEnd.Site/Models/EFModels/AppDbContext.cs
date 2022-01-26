using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShoppingSite_BackEnd.Site.Models.EFModels
{
	public partial class AppDbContext : DbContext
	{
		public AppDbContext()
				: base("name=AppDbContext")
		{
		}

		public virtual DbSet<CartItem> CartItems { get; set; }
		public virtual DbSet<Cart> Carts { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Faq> Faqs { get; set; }
		public virtual DbSet<HotProduct> HotProducts { get; set; }
		public virtual DbSet<Member> Members { get; set; }
		public virtual DbSet<News> News { get; set; }
		public virtual DbSet<OrderItem> OrderItems { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<Poll> Polls { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Recommendation> Recommendations { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>()
					.HasMany(e => e.HotProducts)
					.WithRequired(e => e.Category)
					.WillCascadeOnDelete(false);

			modelBuilder.Entity<Category>()
					.HasMany(e => e.Polls)
					.WithRequired(e => e.Category)
					.WillCascadeOnDelete(false);

			modelBuilder.Entity<Category>()
					.HasMany(e => e.Products)
					.WithRequired(e => e.Category)
					.WillCascadeOnDelete(false);

			modelBuilder.Entity<Member>()
					.Property(e => e.Mobile)
					.IsFixedLength()
					.IsUnicode(false);

			modelBuilder.Entity<Member>()
					.Property(e => e.ConfirmCode)
					.IsUnicode(false);

			modelBuilder.Entity<Member>()
					.HasMany(e => e.Orders)
					.WithRequired(e => e.Member)
					.WillCascadeOnDelete(false);

			modelBuilder.Entity<Order>()
					.Property(e => e.CellPhone)
					.IsFixedLength()
					.IsUnicode(false);

			modelBuilder.Entity<Order>()
					.HasMany(e => e.OrderItems)
					.WithRequired(e => e.Order)
					.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
					.HasMany(e => e.CartItems)
					.WithRequired(e => e.Product)
					.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
					.HasMany(e => e.OrderItems)
					.WithRequired(e => e.Product)
					.WillCascadeOnDelete(false);
		}
	}
}
