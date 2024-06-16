using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;

namespace Bulky.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private readonly ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Product product)
		{
			var objFromDb = _db.Products.FirstOrDefault(s => s.Id == product.Id);
			if (objFromDb != null)
			{
				if (product.ImageUrl != null)
				{
					objFromDb.ImageUrl = product.ImageUrl;
				}
				objFromDb.Title = product.Title;
				objFromDb.ISBN = product.ISBN;
				objFromDb.Price = product.Price;
				objFromDb.Price50 = product.Price50;
				objFromDb.Price100 = product.Price100;
				objFromDb.ListPrice = product.ListPrice;
				objFromDb.Description = product.Description;
				objFromDb.CategoryId = product.CategoryId;
				objFromDb.Author = product.Author;
			}
		}
	}
}
