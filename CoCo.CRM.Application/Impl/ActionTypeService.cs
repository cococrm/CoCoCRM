using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.EntityFramework;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Common;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.Application.Impl
{
    /// <summary>
    /// 权限
    /// </summary>
    public class ActionTypeService : BaseService<ActionType, ActionTypeDTO>, IActionTypeService
    {
        private readonly IActionTypeRepository _actionTypeRepository;
        private readonly IMenuActionRepository _menuActionRepository;

        public ActionTypeService(
            IActionTypeRepository actionTypeRepository,
            IMenuActionRepository menuActionRepository)
            : base(actionTypeRepository)
        {
            this._actionTypeRepository = actionTypeRepository;
            this._menuActionRepository = menuActionRepository;
        }

        /// <summary>
        /// 根据导航获取权限
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public IEnumerable<MenuActionDTO> GetActionByMenu(Guid menuId)
        {
            var _list = _menuActionRepository.GetAll(o => o.SysMenu_ID.Equals(menuId));
            return Mapper.Map<IEnumerable<MenuAction>, IEnumerable<MenuActionDTO>>(_list);
        }
    }
}
