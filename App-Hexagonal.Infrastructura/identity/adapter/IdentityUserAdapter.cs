using System;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Infrastructura.identity.entity;
using Microsoft.AspNetCore.Identity;

namespace App_Hexagonal.Infrastructura.identity.adapter;

public class IdentityUserAdapter : IUserIdentityPort
{
    private readonly UserManager<ApplicationUser> _userManager;
    public IdentityUserAdapter(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Guid> CreateAsync(Guid tenantId, string email, string userName, string password)
    {
        var user = new ApplicationUser { Id = Guid.NewGuid(), TenantId = tenantId, Email = email, UserName = userName };
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            throw new InvalidOperationException(string.Join(", ", result.Errors.Select(e => e.Description)));

        }
        return user.Id;
    }
}
