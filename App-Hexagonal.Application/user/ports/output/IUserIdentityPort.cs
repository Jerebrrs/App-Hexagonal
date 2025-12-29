
namespace App_Hexagonal.Application.user.ports.output
{
    public interface IUserIdentityPort
    {

        Task<Guid> CreateAsync(
         Guid tenantId,
         string email,
         string userName,
         string password,
         string roles
     );

        Task<UserAuthInfo?> ValidateCredentialsAsync(
        string email,
        string password
    );
    }
}