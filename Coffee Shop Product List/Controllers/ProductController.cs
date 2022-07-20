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
            ProductsList productsList = new ProductsList();
            List<Products> listOfItems = new List<Products>();
            foreach (var item in _coffeeShopDbContext.Products)
            {
                listOfItems.Add(item);
            }
            productsList.ProductList = listOfItems;
            return View(productsList);
        }

        public IActionResult Details(int ID)
        {
            Products targetProduct = null;
            foreach (var item in _coffeeShopDbContext.Products)
            {
                if (item.ID == ID)
                {
                    targetProduct = item;
                    break;
                }
            }
            if (targetProduct != null)
            {
                return View(targetProduct);
            }
            else
            {
                throw new Exception("Something went wrong with your code!");
            }

        }
    }
}
