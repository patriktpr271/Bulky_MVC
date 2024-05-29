using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
	[BindProperties]
	public class DeleteModel : PageModel
	{
		private readonly ApplicationDbContext _db;
		public Category Category { get; set; }

		public DeleteModel(ApplicationDbContext dbContext)
		{
			_db = dbContext;
		}
		
		public void OnGet(int? id)
		{
			if (id != null || id != 0)
			{
				Category = _db.Categories.Find(id);
			}
		}

		public IActionResult OnPost()
		{
			Category? deletable = _db.Categories.Find(Category.Id);
			if (deletable == null)
			{
				return NotFound();
			}
			_db.Categories.Remove(deletable);
			_db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToPage("Index");

		}
	}
}
