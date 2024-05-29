using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
	public class CreateModel : PageModel
	{
		private readonly ApplicationDbContext _db;

		public CreateModel(ApplicationDbContext dbContext)
		{
			_db = dbContext;
		}
		[BindProperty]
		public Category Category { get; set; }
		public void OnGet()
		{

		}

		public IActionResult OnPost()
		{
			_db.Categories.Add(Category);
			_db.SaveChanges();
			TempData["success"] = "Category created successfully";
			return RedirectToPage("Index");
		}
	}
}
