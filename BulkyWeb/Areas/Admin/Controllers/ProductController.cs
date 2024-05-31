using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(IUnitOfWork productRepository)
		{
				_unitOfWork = productRepository;
		}

		public IActionResult Index()
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
			return View(objProductList);
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(Product obj)
		{
			if (obj.Author.ToLower() == obj.Title.ToLower())
			{
				ModelState.AddModelError("Author", "Author and Title cannot be the same");
			}
			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Add(obj);
				_unitOfWork.Save();
				TempData["Success"] = "Product created successfully";
				return RedirectToAction("Index", "Product");
			}
			return View();
		}

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0) return NotFound();

			Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
			if (productFromDb == null) return NotFound();

			return View(productFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Product obj)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.Product.Update(obj);
				_unitOfWork.Save();
				TempData["Success"] = "Product has been updated successfully";
				return RedirectToAction("Index", "Product");
			}
			return View();
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0) return NotFound();

			Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
			if (productFromDb == null) return NotFound();

			return View(productFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Product prod = _unitOfWork.Product.Get(u => u.Id == id);
			if (prod == null) return NotFound();

			_unitOfWork.Product.Remove(prod);
			_unitOfWork.Save();
			TempData["Success"] = "Category deleted successfully";
			return RedirectToAction("Index", "Product");
		}
	}
}
