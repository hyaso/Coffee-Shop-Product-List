using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Coffee_Shop_Product_List.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private CoffeeShopDbContext _coffeeShopDbContext;
        

        public ProductController(ILogger<HomeController> logger, CoffeeShopDbContext newCoffeeShopDbContext)
        {
            _logger = logger;
            _coffeeShopDbContext = newCoffeeShopDbContext;
        }

        public ActionResult Index()
        {
            var productList = _coffeeShopDbContext.Products.ToArray();
            return View(productList);
        }

        public IActionResult Details(int productID)
        {
            Products productDescription = null;
            var productList = _coffeeShopDbContext.Products.ToArray();
            foreach (var product in productList)
            {
                if (product.ID == productID)
                {
                    productDescription = product;
                    break;
                }
            }

            if (productDescription != null)
            {
                return View(productDescription);
            }
            else
            {
                throw new Exception("Sorry");
            }
        }
    }
}
