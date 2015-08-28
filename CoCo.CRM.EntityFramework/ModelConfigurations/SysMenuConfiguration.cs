using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// 系统导航
    /// </summary>
    public class SysMenuConfiguration : EntityTypeConfiguration<SysMenu>
    {
        public SysMenuConfiguration()
        {
            ToTable("menu", "hr");
            HasKey<Guid>(o => o.ID);
            Property(o => o.MenuName)
                .IsRequired()
                .HasMaxLength(100);
            Property(o => o.MenuCode)
                .IsRequired()
                .HasMaxLength(100);
            Property(o => o.SortId)
                .IsRequired();
            Property(o => o.LinkUrl)
                .HasMaxLength(255);
            Property(o => o.ParentId)
                .IsOptional();
        }
    }
}
