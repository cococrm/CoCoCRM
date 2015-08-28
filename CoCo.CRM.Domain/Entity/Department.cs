using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoCo.CRM.Domain.Entity
{
    /// <summary>
    /// 部门架构
    /// </summary>
    public class Department : AggregateRoot
    {
        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父ID
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// 岗位列表
        /// </summary>
        public virtual IList<Post> Posts { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
