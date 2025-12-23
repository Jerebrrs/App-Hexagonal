using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App_Hexagonal.Infrastructura.tenant.persistence.entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App_Hexagonal.Infrastructura.tenant.persistence.config
{
    public class TenantEntityConfiguration : IEntityTypeConfiguration<TenantEntity>
    {
        public void Configure(EntityTypeBuilder<TenantEntity> builder)
        {
            builder.ToTable("Tenants");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(t => t.IsActive)
                   .IsRequired();

            builder.HasMany(t => t.Users)
                   .WithOne(u => u.Tenant)
                   .HasForeignKey(u => u.TenantId);
        }
    }
}