using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.Application
{
    /// <summary>
    /// 服务基类接口
    /// </summary>
    /// <typeparam name="BaseDTO"></typeparam>
    public interface IBaseService<Tkey, BaseDTO>
        where BaseDTO : class,IBaseDTO<Tkey>
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        void Add(BaseDTO entity);
        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        void Update(BaseDTO entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(BaseDTO entity);
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="key"></param>
        void Delete(Tkey key);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        void Delete(IList<BaseDTO> list);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        void Delete(IList<Tkey> list);
        /// <summary>
        /// 根据主键获取
        /// </summary>
        /// <param name="key"></param>
        BaseDTO GetByKey(Tkey key);
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        IList<BaseDTO> GetAll();
        /// <summary>
        /// 查询全部分页
        /// </summary>
        /// <returns></returns>
        PagedResult<BaseDTO> GetAllByPage();
        /// <summary>
        /// 查询全部分页
        /// </summary>
        /// <returns></returns>
        PagedResult<BaseDTO> GetAllByPage(Pager pager);
    }
    public interface IBaseService<BaseDTO> : IBaseService<Guid, BaseDTO>
        where BaseDTO : class,IBaseDTO
    { }

}
