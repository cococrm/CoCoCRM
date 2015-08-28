using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            ToTable("post", "hr");
            HasKey(o => o.ID);
            Property(o => o.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(25);
            HasRequired(o => o.Department).WithMany().HasForeignKey(o => o.DepartmentId);
        }
    }
}
