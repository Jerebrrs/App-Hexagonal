using System;
using App_Hexagonal.Application.user.ports.output;
using App_Hexagonal.Infrastructura.identity.entity;
using Microsoft.AspNetCore.Identity;

namespace App_Hexagonal.Infrastructura.identity.adapter;

public class IdentityUserAdapter : IUserIdentityPort
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public IdentityUserAdapter(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole<Guid>> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Guid> CreateAsync(
    Guid tenantId,
    string email,
    string userName,
    string password,
    string roles)
    {
        var user = new ApplicationUser
        {
            Id = Guid.NewGuid(),
            TenantId = tenantId,
            Email = email,
            UserName = userName,
            EmailConfirmed = false
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            throw new InvalidOperationException(
                string.Join(", ", result.Errors.Select(e => e.Description))
            );

        // Crear rol si no existe
        if (!await _roleManager.RoleExistsAsync(roles))
        {
            await _roleManager.CreateAsync(new IdentityRole<Guid>(roles));
        }

        await _userManager.AddToRoleAsync(user, roles);

        return user.Id;
    }

    public async Task<UserAuthInfo?> ValidateCredentialsAsync(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null) return null;

        var valid = await _userManager.CheckPasswordAsync(user, password);

        if (!valid) return null;

        var roles = await _userManager.GetRolesAsync(user);

        return new UserAuthInfo(
            user.Id,
            user.TenantId,
            user.Email!,
            roles.AsReadOnly()
        );
    }
}
