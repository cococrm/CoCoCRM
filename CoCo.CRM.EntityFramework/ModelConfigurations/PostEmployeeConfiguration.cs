using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// 员工部门关系对应
    /// </summary>
    public class PostEmployeeConfiguration : EntityTypeConfiguration<PostEmployee>
    {
        public PostEmployeeConfiguration()
        {
            ToTable("post_employee","hr");
            HasKey(o => o.ID);
            Property(o => o.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.PostId)
                .IsRequired();
            Property(o => o.EmployeeId)
                .IsRequired();
        }
    }
}
