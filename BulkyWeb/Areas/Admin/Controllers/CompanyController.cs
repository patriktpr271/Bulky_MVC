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
	public class CompanyController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public CompanyController(IUnitOfWork CompanyRepository)
		{
			_unitOfWork = CompanyRepository;
		}

		public IActionResult Index()
		{
			List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
			return View(objCompanyList);
		}

		public IActionResult UpSert(int? id) // Upsert is a combination of insert and update
		{
			
			
			if(id == null || id == 0)
			{
				// This is for create
				return View(new Company());
			}
			else
			{
				// This is for edit
				Company company = _unitOfWork.Company.Get(u => u.Id == id);
				return View(company);
			}
			
		}
		[HttpPost]
		public IActionResult UpSert(Company company)
		{
			if (ModelState.IsValid)
			{			

				if(company.Id != 0)
				{
					_unitOfWork.Company.Update(company);
				}
				else
				{
					_unitOfWork.Company.Add(company);
				}

				_unitOfWork.Save();
				TempData["Success"] = "Company created successfully";
				return RedirectToAction("Index", "Company");
			}
			else
			{
				

				return View(company);
			}
		}


		#region API CALLS

		[HttpGet]
		public IActionResult GetAll()
		{
			List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
			return Json(new { data = objCompanyList });
		}
		[HttpDelete]
		public IActionResult Delete(int? id)
		{
			var CompanyToDelete = _unitOfWork.Company.Get(u => u.Id == id);
			if(CompanyToDelete == null)
			{
				return Json(new { success = false, message = "Error while deleting" });
			}
			_unitOfWork.Company.Remove(CompanyToDelete);
			_unitOfWork.Save();
			return Json(new { success = true, message = "Delete successful" });
		}

		#endregion
	}
}
