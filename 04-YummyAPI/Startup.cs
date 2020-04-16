using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using RecipesAPI;

namespace RecipesAPI
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
            services.AddDbContext<RecipesContext>(opt =>
               opt.UseInMemoryDatabase("Recipes"));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            //app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Remove",
                    pattern: "api/Recipes/Remove/{id?}",
                    defaults: new { controller = "Recipes", action = "DeleteRecipe" });

                endpoints.MapControllerRoute(
                    name: "Item",
                    pattern: "api/Recipes/Item/{id?}",
                    defaults: new { controller = "Recipes", action = "GetRecipe" });

                endpoints.MapControllerRoute(
                    name: "Main",
                    pattern: "api/Recipes/Main",
                    defaults: new { controller = "Recipes", action = "GetRecipes" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Recipes}/{action=GetRecipes}/{id?}");
            });
        }
    }
}
