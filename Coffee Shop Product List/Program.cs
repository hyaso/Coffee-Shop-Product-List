using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;



namespace Coffee_Shop_Product_List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddControllersWithViews();
            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<CoffeeShopDbContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());
        }
    }

    public class CoffeeShopDbContext : DbContext
    {
        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options) : base(options)
        {
            // Nothing needed
        }

        public DbSet<Products> Products { get; set; }
    }

    public class Products
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

    }

    public class ProductsList
    {
        public List<Products> ProductList { get; set; }

    }


}