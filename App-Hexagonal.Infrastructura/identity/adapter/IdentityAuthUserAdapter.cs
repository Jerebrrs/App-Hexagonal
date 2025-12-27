using System;
using App_Hexagonal.Infrastructura.identity.entity;
using App_Hexagonal.Infrastructura.tenant.ports.output;
using Microsoft.AspNetCore.Identity;

namespace App_Hexagonal.Infrastructura.identity.adapter;

public class IdentityAuthUserAdapter : IAuthUserPort
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    public IdentityAuthUserAdapter(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<Guid> CreateAdminUserAsync(Guid tenantId, string email, string userName, string password)
    {
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));
        }
        var user = new ApplicationUser(tenantId, email, userName);
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new Exception(string.Join(" | ", result.Errors.Select(e => e.Description)));
        }
        await _userManager.AddToRoleAsync(user, "Admin");
        return user.Id;
    }
}
