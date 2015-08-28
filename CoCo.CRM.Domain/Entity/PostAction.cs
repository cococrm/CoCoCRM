using System;
using System.Data.Entity;

namespace CoCo.CRM.Domain.Entity
{
    /// <summary>
    /// 部门权限
    /// </summary>
    public class PostAction : AggregateRoot
    {
        /// <summary>
        /// 部门
        /// </summary>
        public Guid PostId { get; set; }
        public virtual Post Post { get; set; }
        /// <summary>
        /// 导航
        /// </summary>
        public Guid SysMenuId { get; set; }
        public virtual SysMenu SysMenu { get; set; }
        /// <summary>
        /// 操作权限
        /// </summary>
        public Guid ActionTypeId { get; set; }
        public virtual ActionType ActionType { get; set; }
    }
}
