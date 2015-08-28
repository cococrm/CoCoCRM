using System;
using System.Collections.Generic;

namespace CoCo.CRM.ModelDTO
{
    /// <summary>
    /// 操作权限
    /// </summary>
    public class ActionTypeDTO : BaseDTO
    {
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        //public virtual IList<SysMenuDTO> SysMenus { get; set; }
    }
}
