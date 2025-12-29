namespace App_Hexagonal.Application.Common.security
{
    public static class Policies
    {
        public const string TenantAdmin = "TenantAdmin";
        public const string TenantUser = "TenantUser";
        public const string AuthenticatedUser = "AuthenticatedUser";


        public const string AdminOnly = "AdminOnly";
        public const string RequireAdmin = "RequireAdmin";
        public const string SameTenant = "SameTenant";
    }
}