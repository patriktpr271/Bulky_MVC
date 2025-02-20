using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
	public class IndexModel : PageModel
	{
		private readonly ApplicationDbContext _db;

		public IndexModel(ApplicationDbContext dbContext)
		{
				_db = dbContext;
		}

		public List<Category> CategoryList { get; set; }
		public void OnGet()
		{
			CategoryList = _db.Categories.ToList();
		}
	}
}
