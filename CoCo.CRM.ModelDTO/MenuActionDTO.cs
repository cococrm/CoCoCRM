using System;
using System.Collections.Generic;

namespace CoCo.CRM.ModelDTO
{
    public class MenuActionDTO : BaseDTO
    {
        /// <summary>
        /// 导航ID
        /// </summary>
        public Guid SysMenu_ID { get; set; }
        /// <summary>
        /// 操作ID
        /// </summary>
        public Guid ActionType_ID { get; set; }
    }
}
