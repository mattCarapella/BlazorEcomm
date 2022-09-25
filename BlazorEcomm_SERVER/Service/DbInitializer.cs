using BlazorEcomm_COMMON;
using BlazorEcomm_DATA.Data;
using BlazorEcomm_SERVER.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlazorEcomm_SERVER.Service;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    
    public DbInitializer(ApplicationDbContext db, 
                         UserManager<IdentityUser> userManager, 
                         RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void Initialize()
    {
        try
        {
            /* Check if there are any pending migrations */
            if (_db.Database.GetPendingMigrations().Any()) _db.Database.Migrate();

            /* Before a user is created, we want to assign them a role. This checks if any roles exists and if 
               not will create them. It will only run once. */
            if (!_roleManager.RoleExistsAsync(StaticDetails.ROLE_ADMIN).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_ADMIN)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(StaticDetails.ROLE_CUSTOMER)).GetAwaiter().GetResult();
            }
            else
            {
                return;
            }

            /* Create an initial user and assign to Admin role. */
            IdentityUser user = new()
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
                EmailConfirmed = true
            };

            _userManager.CreateAsync(user, "Pa$$w0rd").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, StaticDetails.ROLE_ADMIN).GetAwaiter().GetResult();

        }
        catch (Exception ex)
        {

        }
    }

}
