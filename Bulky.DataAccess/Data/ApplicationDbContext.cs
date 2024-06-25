using Bulky.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Company> Companies { get; set; }
		public DbSet<ShoppingCart> ShoppingCarts { get; set; }
		public DbSet<OrderHeader> OrderHeaders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(
				new Category { CategoryId = 1, Name = "Headphones", DisplayOrder = 1 },
				new Category { CategoryId = 2, Name = "Smartphones", DisplayOrder = 2 },
				new Category { CategoryId = 3, Name = "Tablets", DisplayOrder = 3 },
				new Category { CategoryId = 4, Name = "Gaming Consoles", DisplayOrder = 4 }
			);

			modelBuilder.Entity<Company>().HasData(
				new Company {
					Id = 1,
					Name = "Sony",
					StreetAddress = "Kecskeméti utca 4",
					City = "Budapest",
					State = "Pest",
					PostalCode = "1053",
					PhoneNumber = "+36 1 317 4974",
				},
				new Company
				{
					Id = 2,
					Name = "Apple",
					StreetAddress = "Könyves Kálmán krt 12-14",
					City = "Budapest",
					State = "Pest",
					PostalCode = "1095",
					PhoneNumber = "+36 30 730 1143",
				},
				new Company
				{
					Id = 3,
					Name = "Microsoft",
					StreetAddress = "920 Fourth Avenue, Suite 2900",
					City = "Seattle",
					State = "Washington",
					PostalCode = "95104",
					PhoneNumber = "+800 426 9400",
				}
			);

			modelBuilder.Entity<Product>().HasData(
				new Product
				{
					Id = 1,
					ProductName = "WH-1000XM4 Wireless Noise-Cancelling Headphones",
					Brand = "Sony",
					Description = " The Sony WH-1000XM4 offers superior noise-cancellation, 30-hour battery life, and high-resolution audio quality." +
					" Equipped with touch sensor controls, quick attention mode, and wearing detection, these headphones provide an exceptional listening experience.",
					SKU = "WH-1000XM4",
					ListPrice = 349.99,
					Price = 349.99,
					Price50 = 300,
					Price100 = 279.99,
					CategoryId = 1,
					ImageUrl = ""
				},
				new Product
				{
					Id = 2,
					ProductName = "Apple iPhone 14 Pro",
					Brand = "Apple",
					Description = "The Apple iPhone 14 Pro features a stunning 6.1-inch Super Retina XDR display, A16 Bionic chip, and an advanced camera system with ProRAW and ProRes video capabilities." +
					" With 5G support, Face ID, and a ceramic shield front cover, it offers unmatched performance and durability.",
					SKU = "IP14PRO",
					ListPrice = 999.99,
					Price = 999.99,
					Price50 = 949.99,
					Price100 = 899.99,
					CategoryId = 2,
					ImageUrl = ""
				},			
				new Product
				{
					Id = 4,
					ProductName = " Microsoft Surface Pro 9",
					Brand = "Microsoft",
					Description = "The Microsoft Surface Pro 9 combines the power of a laptop with the flexibility of a tablet. It features a 13-inch PixelSense touchscreen, 11th Gen Intel Core processor, and up to 15 hours of battery life. " +
					"With its detachable keyboard and Surface Pen compatibility, it's perfect for both work and creativity. ",
					SKU = "SURFACEPRO9",
					ListPrice = 1199.99,
					Price = 1199.99,
					Price50 = 1100,
					Price100 = 999.99,
					CategoryId = 3,
					ImageUrl = ""
				},
				new Product
				{
					Id = 5,
					ProductName = "Sony PlayStation 5",
					Brand = "Sony",
					Description = "The Sony PlayStation 5 (PS5) is a cutting-edge gaming console that offers ultra-high-speed SSD, haptic feedback, adaptive triggers, and 3D audio technology." +
					" With stunning 4K graphics and lightning-fast load times, it delivers an immersive gaming experience. ",
					SKU = "PS5",
					ListPrice = 499.99,
					Price = 499.99,
					Price50 = 400,
					Price100 = 349.99,
					CategoryId = 4,
					ImageUrl = ""
				},
				new Product
				{
					Id = 6,
					ProductName = "Apple MacBook Pro 16-inch",
					Brand = "Apple",
					Description = " The Apple MacBook Pro 16-inch features a stunning Retina display, powerful M1 Pro chip, and up to 21 hours of battery life." +
					" With a Magic Keyboard, Touch Bar, and up to 64GB of unified memory, it’s designed for professionals who need high performance and versatility. ",
					SKU = "MBP16M1PRO",
					ListPrice = 2499.99,
					Price = 2499.99,
					Price50 = 2399.99,
					Price100 = 2199.99,
					CategoryId = 3,
					ImageUrl = ""
				},
				new Product
				{
					Id = 7,
					ProductName = "Microsoft Xbox Series X",
					Brand = "Microsoft",
					Description = " The Microsoft Xbox Series X is the most powerful Xbox ever, featuring a custom AMD Zen 2 processor, 12 teraflops of processing power, and support for 8K resolution. " +
					"With a 1TB SSD and backward compatibility, it offers exceptional performance and an expansive game library.",
					SKU = "XBOXSERIESX",
					ListPrice = 499.99,
					Price = 499.99,
					Price50 = 450,
					Price100 = 399.99,
					CategoryId = 4,
					ImageUrl = ""
				}
			);

		}
	}
}
