using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BulkyWeb.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Authorize]
	public class ShoppingCartController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ShoppingCartVM ShoppingCartVM { get; set; }
		public ShoppingCartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			ShoppingCartVM = new ShoppingCartVM()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
				includeProperties:"Product")
			};

			foreach(var cart in ShoppingCartVM.ShoppingCartList)
			{
				cart.Price = GetPriceBasedOnQuantity(cart);
				ShoppingCartVM.OrderTotal += cart.Price * cart.Count;
			}

			return View(ShoppingCartVM);
		}

		public IActionResult Plus(int cartId) 
		{
			var cart = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
			cart.Count += 1;
			_unitOfWork.ShoppingCart.Update(cart);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Minus(int cartId)
		{
			var cart = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
			cart.Count -= 1;
			if(cart.Count == 0)
			{
				_unitOfWork.ShoppingCart.Remove(cart);
			}
			else
			{
				_unitOfWork.ShoppingCart.Update(cart);
			}            
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int cartId)
		{
			var cart = _unitOfWork.ShoppingCart.Get(c => c.Id == cartId);
			_unitOfWork.ShoppingCart.Remove(cart);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Summary()
		{
			return View();
		}

		private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
		{
			int count = shoppingCart.Count;
			if(count <= 50)
			{
				return shoppingCart.Product.Price;
			}
			else
			{
				if(count <= 100)
				{
					return shoppingCart.Product.Price50;
				}
				else
				{
					return shoppingCart.Product.Price100;
				}
			}
		}
	}
}
