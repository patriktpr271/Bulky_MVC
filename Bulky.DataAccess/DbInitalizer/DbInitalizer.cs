using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.DbInitalizer
{
	public class DbInitalizer : IDbInitalizer
	{
		private readonly ApplicationDbContext _db;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _userManager;

		public DbInitalizer(ApplicationDbContext db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
		{
			_db = db;
			_roleManager = roleManager;
			_userManager = userManager;
		}
		public void Initalize()
		{
			//push migrations if they are not applied
			try
			{
				if(_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}

			}catch (Exception ex)
			{ }

			//create roles if they do not exist
			if(!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Company)).GetAwaiter().GetResult();

				//if roles are not created, create an admin user
				_userManager.CreateAsync(new ApplicationUser
				{
					UserName = "Admin",
					Email = "admin@gmail.com",
					Name = "Admin User",
					PhoneNumber = "1234567890",
					StreetAddress = "123 Admin St",
					City = "Admin City",
					PostalCode = "12345",
					State = "Admin State",


				},
			"Admin123@").GetAwaiter().GetResult();

				ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "admin@gmail.com");
				_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();
			}
		}
		
	}

	
}
