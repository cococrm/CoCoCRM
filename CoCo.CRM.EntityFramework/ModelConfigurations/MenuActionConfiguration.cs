using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    public class MenuActionConfiguration : EntityTypeConfiguration<MenuAction>
    {
        public MenuActionConfiguration()
        {
            ToTable("menu_action", "hr");
            HasKey<Guid>(o => o.ID);
            Property(o => o.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.ActionType_ID)
                .IsRequired();
            Property(o => o.SysMenu_ID)
                .IsRequired();
        }
    }
}
