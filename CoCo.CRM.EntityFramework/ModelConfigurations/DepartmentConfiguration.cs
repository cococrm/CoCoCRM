using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// 部门
    /// </summary>
    public class DepartmentConfiguration : EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("department", "hr");
            HasKey(o => o.ID);
            Property(o => o.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(25);
            HasMany(o => o.Posts).WithRequired(oo => oo.Department).HasForeignKey(oo => oo.DepartmentId);
        }
    }
}
