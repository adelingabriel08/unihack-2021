using System.IO;
using System.Text.Json.Serialization;
using HelpYourCity.Persistence;
﻿using HelpYourCity.Core.MapperProfiles;
using HelpYourCity.Persistence;
using HelpYourCity.Persistence.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Stripe;

namespace HelpYourCity.API
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

            // Add services to the container.
            
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddPersistenceServices(Configuration.GetConnectionString("HelpYourCity"));
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddCors(options =>
                {
                    options.AddPolicy(name: "CorsPolicy", builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
                }
            );
            services.AddPersistenceServices(Configuration.GetConnectionString("HelpYourCity"));
            
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            StripeConfiguration.ApiKey = Configuration["Stripe:SecretKey"];
            app.UseSwagger();
            app.UseSwaggerUI();
            // for wwwroot for css and js stuff
            var uploadedsDirectory = Path.Combine("content");
            if (!Directory.Exists(uploadedsDirectory))
            {
                Directory.CreateDirectory(uploadedsDirectory);
            }
            
            app.UseStaticFiles();
            
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "content")),
                RequestPath = "/content",
                
            });


            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

        }
    }
}
