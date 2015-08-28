using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    /// <summary>
    /// 操作权限
    /// </summary>
    public class ActionTypeConfiguration : EntityTypeConfiguration<ActionType>
    {
        public ActionTypeConfiguration()
        {
            ToTable("action_type", "hr");
            HasKey<Guid>(o => o.ID);
            Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(25);
            Property(o => o.Action)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
