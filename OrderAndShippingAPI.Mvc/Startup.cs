using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrderAndShippingAPI.Data.Abstract;
using OrderAndShippingAPI.Data.Concrete;
using OrderAndShippingAPI.Data.Concrete.EFCore.Contexts;
using OrderAndShippingAPI.Data.Concrete.EFCore.Repositories;
using OrderAndShippingAPI.Entities.Concrete;
using OrderAndShippingAPI.Services.Abstract;
using OrderAndShippingAPI.Services.AutoMapper.Profiles;
using OrderAndShippingAPI.Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAndShippingAPI.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(ProductProfile));
            services.AddRazorPages();

            services.AddDbContext<OrderAndShippingContext>(option=>
            {
                option.UseSqlServer(Configuration.GetConnectionString("LokalDB"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Manager
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Shipping Api", Version = "v2" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Shipping Api");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
