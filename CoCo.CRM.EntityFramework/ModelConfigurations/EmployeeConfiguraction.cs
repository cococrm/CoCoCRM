using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    public class EmployeeConfiguraction:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguraction()
        {
            ToTable("employee", "hr");
            HasKey<Guid>(o => o.ID);
            Property(o => o.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.UserName)
                .IsRequired()
                .HasMaxLength(25);
            Property(o => o.Password)
                .IsRequired()
                .HasMaxLength(100);
            Property(o => o.RealName)
                .IsRequired()
                .HasMaxLength(25);
            Property(o => o.Phone)
                .HasMaxLength(25);
            Property(o => o.Email)
                .HasMaxLength(50);
            Property(o => o.Address)
                .HasMaxLength(100);
            Property(o => o.UpdateDate)
                .IsOptional();
            Property(o => o.LoginDate)
                .IsOptional();
        }
    }
}
