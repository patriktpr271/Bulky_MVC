using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModel;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin)]
	public class ProductController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _hostingEnvironment;

		public ProductController(IUnitOfWork productRepository, IWebHostEnvironment hostingEnvironment)
		{
			_unitOfWork = productRepository;
			_hostingEnvironment = hostingEnvironment;
		}

		public IActionResult Index()
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
			return View(objProductList);
		}

		public IActionResult UpSert(int? id) // Upsert is a combination of insert and update
		{
			
			ProductVM productVM = new ProductVM()
			{
				Product = new Product(),
				CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.CategoryId.ToString()
				})
			};
			if(id == null || id == 0)
			{
				// This is for create
				return View(productVM);
			}
			else
			{
				// This is for edit
				productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
			}
			return View(productVM);
		}
		[HttpPost]
		public IActionResult UpSert(ProductVM productVM, IFormFile? file)
		{
			if (ModelState.IsValid)
			{
				string webRootPath = _hostingEnvironment.WebRootPath;
				if(file != null)
				{
					string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
					var productPath = Path.Combine(webRootPath, @"images\product");

					if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
					{
						//delete old image
						var imagePath = Path.Combine(webRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
						if (System.IO.File.Exists(imagePath))
						{
							System.IO.File.Delete(imagePath);
						}
					}

					using(FileStream fileStream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					productVM.Product.ImageUrl = @"\images\product\" + filename;
				}

				if(productVM.Product.Id != 0)
				{
					_unitOfWork.Product.Update(productVM.Product);
				}
				else
				{
					_unitOfWork.Product.Add(productVM.Product);
				}

				_unitOfWork.Save();
				TempData["Success"] = "Product created successfully";
				return RedirectToAction("Index", "Product");
			}
			else
			{
				productVM.CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
				{
					Text = i.Name,
					Value = i.CategoryId.ToString()
				});

				return View(productVM);
			}
		}


		#region API CALLS

		[HttpGet]
		public IActionResult GetAll()
		{
			List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
			return Json(new { data = objProductList });
		}
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var productToDelete = _unitOfWork.Product.Get(u => u.Id == id);
			if(productToDelete == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}

			var oldImagePath = Path.Combine(_hostingEnvironment.WebRootPath, productToDelete.ImageUrl.TrimStart('\\'));
			if (System.IO.File.Exists(oldImagePath))
			{
				System.IO.File.Delete(oldImagePath);
			}
			_unitOfWork.Product.Remove(productToDelete);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete successful" });
		}

		#endregion
	}
}
