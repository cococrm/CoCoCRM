using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoCo.CRM.Domain.Entity
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class Post : AggregateRoot
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// 权限菜单
        /// </summary>
        public virtual IList<PostAction> PostAction { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
