using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework.ModelConfigurations
{
    public class PostActionConfiguration : EntityTypeConfiguration<PostAction>
    {
        public PostActionConfiguration()
        {
            ToTable("post_menu_action", "hr");
            HasKey(o => o.ID);
            Property(o => o.ID)
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
