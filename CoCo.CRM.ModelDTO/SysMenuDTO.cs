using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CoCo.CRM.ModelDTO
{
    /// <summary>
    /// 导航
    /// </summary>
    public class SysMenuDTO : BaseDTO
    {
        /// <summary>
        /// 导航名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 导航代码
        /// </summary>
        public string MenuCode { get; set; }
        /// <summary>
        /// 链接地址
        /// </summary>
        public string LinkUrl { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 是否锁定
        /// </summary>
        public bool IsLock { get; set; }
        /// <summary>
        /// 父目录
        /// </summary>
        public Guid ParentId { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public virtual IList<ActionTypeDTO> Action { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }
        [JsonProperty(PropertyName = "children", NullValueHandling = NullValueHandling.Ignore)]
        public IList<SysMenuDTO> Children { get; set; }
    }
}
