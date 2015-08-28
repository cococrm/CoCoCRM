using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoCo.CRM.Domain.Repositories
{
    public abstract class RepositoryContext : IRepositoryContext
    {
        private volatile bool committed = true;
        /// <summary>
        /// Gets a <see cref="System.Boolean"/> value which indicates
        /// whether the Unit of Work was successfully committed.
        /// </summary>
        public virtual bool Committed
        {
            get { return committed; }
            set { committed = value; }
        }
        /// <summary>
        /// Commits the transaction.
        /// </summary>
        public abstract void Commit();
        /// <summary>
        /// Rollback the transaction.
        /// </summary>
        public abstract void Rollback();
    }
}
