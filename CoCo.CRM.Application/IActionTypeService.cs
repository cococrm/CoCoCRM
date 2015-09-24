using System;
using System.Collections;
using System.Collections.Generic;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Common;


namespace CoCo.CRM.Application
{
    /// <summary>
    /// 权限
    /// </summary>
    public interface IActionTypeService : IBaseService<ActionTypeDTO>
    {
        /// <summary>
        /// 根据导航获取权限
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        IEnumerable<MenuActionDTO> GetActionByMenu(Guid menuId);
    }
}
