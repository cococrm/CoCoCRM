using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CoCo.CRM.Domain;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.EntityFramework;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Infrastructure;
using AutoMapper;

namespace CoCo.CRM.Application
{
    /// <summary>
    /// 服务基类，子类继承实现具体操作
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    /// <typeparam name="TAggregateRoot"></typeparam>
    /// <typeparam name="BaseDTO"></typeparam>
    public abstract class BaseService<Tkey, TAggregateRoot, BaseDTO> : IBaseService<Tkey, BaseDTO>
        where TAggregateRoot : class,IAggregateRoot<Tkey>
        where BaseDTO : class ,IBaseDTO<Tkey>
    {
        private readonly IRepository<Tkey, TAggregateRoot> _repository;

        public BaseService(IRepository<Tkey, TAggregateRoot> repository)
        {
            this._repository = repository;
        }
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="addEntitys"></param>
        /// <param name="updateEntitys"></param>
        /// <param name="deleteEntitys"></param>
        public virtual void Save(IList<BaseDTO> addEntitys, IList<BaseDTO> updateEntitys, IList<BaseDTO> deleteEntitys)
        {
            this.Add(addEntitys);
            this.Update(updateEntitys);
            this.Delete(deleteEntitys);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(BaseDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException("添加数据不能为空！");
            var aggregateRoot = Mapper.Map<BaseDTO, TAggregateRoot>(entity);//Map转换
            _repository.Add(aggregateRoot);
            _repository.Context.Commit();
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entitys"></param>
        public virtual void Add(IList<BaseDTO> entitys)
        {
            if (entitys == null)
                return;
            if (entitys.Count == 0)
                return;
            var aggregateRoots = Mapper.Map<IList<BaseDTO>, IList<TAggregateRoot>>(entitys);
            _repository.Add(aggregateRoots.AsEnumerable());
            _repository.Context.Commit();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(BaseDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException("修改数据不能为空！");
            var aggregateRoot = Mapper.Map<BaseDTO, TAggregateRoot>(entity);
            _repository.Update(aggregateRoot);
            _repository.Context.Commit();
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="entitys"></param>
        public virtual void Update(IList<BaseDTO> entitys)
        {
            if (entitys == null)
                return;
            if (entitys.Count == 0)
                return;
            foreach (var entity in entitys)
            {
                var aggregateRoot = Mapper.Map<BaseDTO, TAggregateRoot>(entity);
                _repository.Update(aggregateRoot);
            }
            _repository.Context.Commit();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(BaseDTO entity)
        {
            if (entity == null)
                throw new ArgumentNullException("删除数据不能为空！");
            var aggregateRoot = Mapper.Map<BaseDTO, TAggregateRoot>(entity);
            _repository.Remove(aggregateRoot);
            _repository.Context.Commit();
        }
        /// <summary>
        /// 主键删除
        /// </summary>
        /// <param name="key"></param>
        public virtual void Delete(Tkey key)
        {
            _repository.Remove(key);
            _repository.Context.Commit();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="list"></param>
        public virtual void Delete(IList<BaseDTO> entitys)
        {
            if (entitys == null)
                return;
            if (entitys.Count == 0)
                return;
            var _list = Mapper.Map<IList<BaseDTO>, IList<TAggregateRoot>>(entitys);
            _repository.Remove(_list);
            _repository.Context.Commit();
        }
        /// <summary>
        /// 批量主键删除
        /// </summary>
        /// <param name="list"></param>
        public virtual void Delete(IList<Tkey> list)
        {
            if (list == null)
                throw new ArgumentNullException("删除数据不能为空！");
            _repository.Remove(list);
            _repository.Context.Commit();
        }
        /// <summary>
        /// 根据主键获取
        /// </summary>
        /// <param name="key"></param>
        public virtual BaseDTO GetByKey(Tkey key)
        {
            var entity = _repository.GetByKey(key);
            if (entity == null)
                return null;
            return Mapper.Map<TAggregateRoot, BaseDTO>(entity);
        }
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public virtual IList<BaseDTO> GetAll()
        {
            var list = _repository.GetAll();
            if (list.Count() == 0)
                return null;
            var _list = Mapper.Map<IEnumerable<TAggregateRoot>, IEnumerable<BaseDTO>>(list);
            return _list.ToList();
        }
        /// <summary>
        /// 查询全部分页
        /// </summary>
        /// <returns></returns>
        public virtual PagedResult<BaseDTO> GetAllByPage()
        {
            return GetAllByPage(new Pager());
        }
        /// <summary>
        /// 查询全部分页
        /// </summary>
        /// <returns></returns>
        public virtual PagedResult<BaseDTO> GetAllByPage(Pager pager)
        {
            var result = _repository.PagerQuery(pager);
            var _result = Mapper.Map<PagedResult<TAggregateRoot>, PagedResult<BaseDTO>>(result);
            return _result;
        }
    }

    public abstract class BaseService<TAggregateRoot, BaseDTO> : BaseService<Guid, TAggregateRoot, BaseDTO>, IBaseService<BaseDTO>
        where TAggregateRoot : class,IAggregateRoot
        where BaseDTO : class ,IBaseDTO
    {
        public BaseService(IRepository<Guid, TAggregateRoot> repository)
            : base(repository)
        {
        }
    }
}
