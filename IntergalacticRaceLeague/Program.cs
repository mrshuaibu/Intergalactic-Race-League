using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.BLL;
using IntergalacticRaceLeague.Repositories;

namespace IntergalacticRaceLeague
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register DbContext with the connection string from appsettings.json
            builder.Services.AddDbContext<IntergalacticRaceLeagueDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Register ASP.NET Identity services
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IntergalacticRaceLeagueDbContext>();

            // Register BLL Services
            builder.Services.AddTransient<RacerService>();
            builder.Services.AddTransient<VehicleService>();
            builder.Services.AddTransient<TournamentService>();
            builder.Services.AddTransient<RaceResultService>();
            builder.Services.AddTransient<StatisticsService>();

            // Register DAL Services
            builder.Services.AddTransient<RacerRepository>();
            builder.Services.AddTransient<VehicleRepository>();
            builder.Services.AddTransient<TournamentRepository>();
            builder.Services.AddTransient<RaceResultRepository>();
            builder.Services.AddTransient<StatisticsRepository>();

            var app = builder.Build();

            // Seed roles and admin user here
            SeedRolesAndAdminUserAsync(app.Services).GetAwaiter().GetResult();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }

        static async Task SeedRolesAndAdminUserAsync(IServiceProvider serviceProvider)
        {
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                RoleManager<IdentityRole> roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                UserManager<IdentityUser> userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                //Define roles
                string[] roles = { "Admin", "User" };
                foreach (string role in roles)
                {
                    if(!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                // Create an admin user
                IdentityUser adminUser = new IdentityUser
                {
                    UserName = "Shuaibumikel@gmail.com",
                    Email = "Shuaibumikel@gmail.com",
                    EmailConfirmed = true
                };
                if (await userManager.FindByEmailAsync(adminUser.Email) == null)
                {
                    await userManager.CreateAsync(adminUser, "Swagelok2020!");
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
