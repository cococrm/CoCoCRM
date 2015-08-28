using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoCo.CRM.Infrastructure
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// 提交标示
        /// </summary>
        bool Committed { get; set; }
        /// <summary>
        /// 提交
        /// </summary>
        void Commit();
        /// <summary>
        /// 回滚
        /// </summary>
        void Rollback();
    }
}
