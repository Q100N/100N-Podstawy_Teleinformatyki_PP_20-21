using System;
using DietaApp.Core;
using DietaApp.Core.Interfaces;
using DietaApp.Core.Mapper;
using DietaApp.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DietaApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DietaAppDbContext>(options => options.
            UseSqlServer("Server=tcp:dietaappserv.database.windows.net,1433;Initial Catalog=DietaAppDB;Persist Security Info=False;User " +
            "ID=dietaappserv;Password=u9jN6K9DgBwIBK;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddControllersWithViews();
            services.AddTransient<IDishRepository, DishRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductsInDishRepository, ProductsInDishRepository>();
            services.AddTransient<IMealRepository,  MealRepository>();
            services.AddTransient<IDishesInMealRepository, DishesInMealRepository>();
            services.AddTransient<IMealsInDayRepository, MealsInDayRepository>();
            services.AddTransient<IDayRepository, DayRepository>();
            services.AddTransient<IShoppingListRepository, ShoppingListRepository>();
            services.AddTransient<IDaysInShoppingListRepository, DaysInShoppingListRepository>();
            services.AddTransient<DtoMapper>();
            services.AddTransient<ViewModelMapper>();
            services.AddTransient<IManager, Manager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            serviceProvider.GetService<DietaAppDbContext>().Database.Migrate();
        }
    }
}
