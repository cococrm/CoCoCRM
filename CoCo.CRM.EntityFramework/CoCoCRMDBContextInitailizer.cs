using System.Data.Entity;

namespace CoCo.CRM.EntityFramework
{
    public sealed class CoCoCRMDBContextInitailizer:DropCreateDatabaseIfModelChanges<CoCoCRMDBContext>
    {
        protected override void Seed(CoCoCRMDBContext context)
        {
            base.Seed(context);
        }

        public static void Initialize()
        {
            Database.SetInitializer<CoCoCRMDBContext>(null);
        }
    }
}
