
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Bulky.Models;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BulkyWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new ShoppingCart()
            {
                Product = _unitOfWork.Product.Get(u=>u.Id== productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart cart)
        {
            //get the user id of the logged in user
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.
                Get(u => u.ApplicationUserId == cart.ApplicationUserId && u.ProductId == cart.ProductId);
            if(cartFromDb != null)
            {
                //shopping cart item already exists for this product and user
                cartFromDb.Count += cart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                //shopping cart item doesn't exist for this product and user so we add a new one
                _unitOfWork.ShoppingCart.Add(cart);
            }
            TempData["success"] = "Cart updated successfully";
            _unitOfWork.Save();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
