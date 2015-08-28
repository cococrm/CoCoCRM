using System;
using System.Linq;
using System.Reflection;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    public sealed class CoCoCRMDBContext : DbContext
    {
        /// <summary>
        /// 构造函数，初始化一个新的<c>ERPDBContext</c>实例。
        /// </summary>
        public CoCoCRMDBContext()
            : base("CoCoCRMDB")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
        }

        #region DbSet
        public DbSet<SysMenu> SysMenus
        {
            get
            {
                return this.Set<SysMenu>();
            }
        }

        public DbSet<ActionType> ActionTypes
        {
            get
            {
                return this.Set<ActionType>();
            }
        }

        public DbSet<Employee> Employees
        {
            get
            {
                return this.Set<Employee>();
            }
        }

        public DbSet<Department> Departments
        {
            get
            {
                return this.Set<Department>();
            }
        }

        public DbSet<Post> Posts
        {
            get
            {
                return this.Set<Post>();
            }
        }

        public DbSet<PostAction> PostActions
        {
            get
            {
                return this.Set<PostAction>();
            }
        }

        #endregion

        /// <summary>
        /// 重新父类方法
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
