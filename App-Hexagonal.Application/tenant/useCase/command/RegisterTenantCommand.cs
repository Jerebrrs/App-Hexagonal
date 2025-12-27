namespace App_Hexagonal.Application.tenant.useCase.command;

public record class RegisterTenantCommand(string TenantName, string AdminEmail, string AdminUserName, string Password);