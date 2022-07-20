using Coffee_Shop_Product_List.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coffee_Shop_Product_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CoffeeShopDbContext _coffeeShopDbContext;

        public HomeController(ILogger<HomeController> logger, CoffeeShopDbContext newRecordStoreContext)
        {
            _logger = logger;
            _coffeeShopDbContext = newRecordStoreContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult CreateUserSubmit(string firstName, string lastName, string email, string password)
        {
            CoffeeUser newUser = new CoffeeUser();
            newUser.FirstName = firstName;
            newUser.LastName = lastName;
            newUser.Email = email;
            newUser.Password = password;

            return RedirectToAction("viewuser", newUser);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        public IActionResult ViewUser(CoffeeUser userInfo)
        {
            return View(userInfo);
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