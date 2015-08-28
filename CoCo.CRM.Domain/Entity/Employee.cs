using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoCo.CRM.Domain.Entity
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee : AggregateRoot
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 是否可以登陆
        /// </summary>
        public bool IsLogin { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public bool State { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime LoginDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
