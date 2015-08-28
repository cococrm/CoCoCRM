using System;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using CoCo.CRM.Infrastructure;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Common;

namespace CoCo.CRM.EntityFramework
{
    public class EntityFrameworkRepositoryContext : RepositoryContext,IEntityFrameworkRepositoryContext
    {
        // ThreadLocal代表线程本地存储，主要相当于一个静态变量
        // 但静态变量在多线程访问时需要显式使用线程同步技术。
        // 使用ThreadLocal变量，每个线程都会一个拷贝，从而避免了线程同步带来的性能开销
        private readonly DbContext efContext;
        private readonly ThreadLocal<CoCoCRMDBContext> localCtx = new ThreadLocal<CoCoCRMDBContext>(() => new CoCoCRMDBContext());
        private readonly object sync = new object();
        public EntityFrameworkRepositoryContext()
        {
            this.efContext = localCtx.Value;
        }

        public DbContext Context
        {
            get { return this.localCtx.Value; }
        }

        public override void Rollback()
        {
            Committed = false;
        }

        public override void Commit()
        {
            if (!Committed)
            {
                lock (sync)
                {
                    try
                    {
                        efContext.SaveChanges();
                    }
                    catch(Exception ex)
                    {
                        Log.Error(ex);
                    }
                }
                Committed = true;
            }
        }
    }
}
