using System;

namespace App_Hexagonal.Domain.Common;

public interface IMultiTenantEntity
{
    Guid TenantId { get; }
}
