using System;
using CoCo.CRM.Domain;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.EntityFramework;
using CoCo.CRM.ModelDTO;
using AutoMapper;
using System.Linq.Expressions;

namespace CoCo.CRM.Application
{
    public abstract class ApplicationService
    {
        /// <summary>
        /// 对应用层服务进行初始化。
        /// </summary>
        /// <remarks>包含的初始化任务有：
        /// 1. AutoMapper框架的初始化</remarks>
        public static void Initialize()
        {
            
            Mapper.CreateMap<SysMenu, SysMenuDTO>();
            Mapper.CreateMap<SysMenuDTO, SysMenu>();
            Mapper.CreateMap<ActionType, ActionTypeDTO>();
            Mapper.CreateMap<ActionTypeDTO, ActionType>();
            Mapper.CreateMap<MenuAction, MenuActionDTO>();
            Mapper.CreateMap<MenuActionDTO, MenuAction>();
        }
    }
}
