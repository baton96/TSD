using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCRecipes.Data;
using Microsoft.EntityFrameworkCore;

namespace MVCRecipes
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
            services.AddControllersWithViews();
            services.AddDbContext<MVCRecipeContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("MVCRecipeContext")
                )
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
                    name: "New",
                    pattern: "Recipes/New",
                    defaults: new { controller = "Recipes", action = "Create" });

                endpoints.MapControllerRoute(
                    name: "Remove",
                    pattern: "Recipes/Remove/{id?}",
                    defaults: new { controller = "Recipes", action = "Delete" });

                endpoints.MapControllerRoute(
                    name: "Item",
                    pattern: "Recipes/Item/{id?}",
                    defaults: new { controller = "Recipes", action = "Details" });

                endpoints.MapControllerRoute(
                    name: "Modify",
                    pattern: "Recipes/Modify/{id?}",
                    defaults: new { controller = "Recipes", action = "Edit" });

                endpoints.MapControllerRoute(
                    name: "Main",
                    pattern: "Recipes/Main",
                    defaults: new { controller = "Recipes", action = "Index" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Recipes}/{action=Index}/{id?}");
            });
        }
    }
}
