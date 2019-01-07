using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ramsay.Data;
using Ramsay.Models;
using Ramsay.Middlewares.MiddlewareExtensions;
using Ramsay.Services.Ramsay.Services.Ramsay.Receipts;
using AutoMapper;
using Ramsay.Services.Ramsay.Services.Ramsay.UserRole;
using Ramsay.Services;

namespace Ramsay
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<RamsayDbContext>(
                options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<RamsayUser, IdentityRole>(opt =>
                 {
                     opt.SignIn.RequireConfirmedEmail = false;
                     opt.Password.RequireLowercase = false;
                     opt.Password.RequireUppercase = false;
                     opt.Password.RequireNonAlphanumeric = false;
                     opt.Password.RequireDigit = false;
                     opt.Password.RequiredUniqueChars = 0;
                     opt.Password.RequiredLength = 3;

                 })
                 
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<RamsayDbContext>();
            services.AddScoped<RamsayReceiptServices>();
            services.AddScoped<IImageUploader,ImageUploader>();
            services.AddScoped<RamsayUserRoles>();
            services.AddTransient<RamsayReceiptServices>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseDataMiddleware();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {

                //   routes.MapRoute(
                //       name: "username",
                //       template: "{controller=ReceiptMannager}/{action}/{string}"
                //   );
                routes.MapRoute(
                   name: "name",
                   template: "{controller=Home}/{action=Index}/{string?}");

                routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");

       

            });
        }
    }
}
