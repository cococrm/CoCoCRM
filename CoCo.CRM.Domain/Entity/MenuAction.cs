using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoCo.CRM.Domain.Entity
{
    /// <summary>
    /// 权限操作对应
    /// </summary>
    public class MenuAction : AggregateRoot
    {
        /// <summary>
        /// 导航ID
        /// </summary>
        public Guid SysMenu_ID { get; set; }

        /// <summary>
        /// 操作ID
        /// </summary>
        public Guid ActionType_ID { get; set; }

        public MenuAction() { }
        public MenuAction(Guid sysId, Guid actionId)
        {
            this.SysMenu_ID = sysId;
            this.ActionType_ID = actionId;
        }
    }
}
