using System;
using EmployeeWebApplication.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using EmployeeWebApplication.Data;
using EmployeeWebApplication.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeWebApplication
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
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<Employee>(options =>
                options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 10;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = false;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
            });

            services.AddScoped<IAuthorizationHandler, EmployeesAuthorizationHandler>();

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IServiceProvider serviceProvider, IApplicationBuilder app, IWebHostEnvironment env, RoleManager<IdentityRole> roleManager, UserManager<Employee> userManager)
        {
            PerformMigrations(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Employees}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            DatabaseSeeder.SeedDataAsync(roleManager, userManager).Wait();
            CreateRolesAsync(serviceProvider).Wait();
        }

        static void PerformMigrations(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.Migrate();
        }

        private async Task CreateRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<Employee>>();

            string[] roles = { "Execuite", "Management", "HumanResources", "Employee"};

            foreach(var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    _ = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
