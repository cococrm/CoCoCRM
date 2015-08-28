using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.Domain.Repositories
{
    public abstract class Repository<TKey, TAggregateRoot> : IRepository<TKey, TAggregateRoot>
        where TAggregateRoot : class , IAggregateRoot<TKey>
    {
        private readonly IRepositoryContext context;

        public Repository(IRepositoryContext context)
        {
            this.context = context;
        }

        public IRepositoryContext Context
        {
            get
            {
                return this.context;
            }
        }

        #region 抽象方法，子类继承
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="aggregateRoot"></param>
        protected abstract void DoAdd(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="aggreateRoots"></param>
        protected abstract void DoAdd(IEnumerable<TAggregateRoot> aggreateRoots);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="aggregateRoot"></param>
        protected abstract void DoUpdate(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="aggregateRoot"></param>
        protected abstract void DoRemove(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="aggreateRoots"></param>
        protected abstract void DoRemove(IEnumerable<TAggregateRoot> aggreateRoots);
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="key"></param>
        protected abstract void DoRemove(TKey key);
        /// <summary>
        /// 根据主键结合移除
        /// </summary>
        /// <param name="keys"></param>
        protected abstract void DoRemove(IEnumerable<TKey> keys);
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="expredicate"></param>
        protected abstract void DoRemove(Expression<Func<TAggregateRoot, bool>> expredicate);
        /// <summary>
        /// 判定是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected abstract bool DoExists(TKey key);
        /// <summary>
        /// 根据条件判定是否存在
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        protected abstract bool DoExists(Expression<Func<TAggregateRoot, bool>> expredicate);
        /// <summary>
        /// 根据Key获取聚合
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected abstract TAggregateRoot DoGetByKey(TKey key);
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="expredicate">条件</param>
        /// <returns></returns>
        protected abstract TAggregateRoot DoSingle(Expression<Func<TAggregateRoot, bool>> expredicate);
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        protected abstract IEnumerable<TAggregateRoot> DoGetAll();
        /// <summary>
        /// 根据条件查询单个
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, bool>> expredicate);
        /// <summary>
        /// 查询所有，排序
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        /// <summary>
        /// 查询所有，排序
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected abstract PagedResult<TAggregateRoot> DoPagerQuery(Pager pager);
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected abstract PagedResult<TAggregateRoot> DoPagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Pager pager);
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="expredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected abstract PagedResult<TAggregateRoot> DoPagerQuery(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager);
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected abstract PagedResult<TAggregateRoot> DoPagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager);


        #endregion

        #region 实现接口方法
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="aggregateRoot"></param>
        public void Add(TAggregateRoot aggregateRoot)
        {
            this.DoAdd(aggregateRoot);
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="aggreateRoots"></param>
        public void Add(IEnumerable<TAggregateRoot> aggreateRoots)
        {
            this.DoAdd(aggreateRoots);
        }
        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="aggregateRoot"></param>
        public void Remove(TAggregateRoot aggregateRoot)
        {
            this.DoRemove(aggregateRoot);
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="aggreateRoots"></param>
        public void Remove(IEnumerable<TAggregateRoot> aggreateRoots)
        {
            this.DoRemove(aggreateRoots);
        }
        /// <summary>
        /// 根据key移除
        /// </summary>
        /// <param name="key"></param>
        public void Remove(TKey key)
        {
            this.DoRemove(key);
        }
        /// <summary>
        /// 根据key批量删除
        /// </summary>
        /// <param name="keys"></param>
        public void Remove(IEnumerable<TKey> keys)
        {
            this.DoRemove(keys);
        }
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="expredicate"></param>
        public void Remove(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            this.DoRemove(expredicate);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="aggregateRoot"></param>
        public void Update(TAggregateRoot aggregateRoot)
        {
            this.DoUpdate(aggregateRoot);
        }
        /// <summary>
        /// 根据Key判定是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Exists(TKey key)
        {
            return this.DoExists(key);
        }
        /// <summary>
        /// 根据条件判定是否存在
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        public bool Exists(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            return this.DoExists(expredicate);
        }
        /// <summary>
        /// 根据Key获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TAggregateRoot GetByKey(TKey key)
        {
            return this.DoGetByKey(key);
        }
        /// <summary>
        /// 根据条件查询单条记录
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        public TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            return this.DoSingle(expredicate);
        }
        /// <summary>
        /// 获取全部
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAll()
        {
            return this.DoGetAll();
        }
        /// <summary>
        /// 根据条件查询所有
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            return this.DoGetAll(expredicate);
        }
        /// <summary>
        /// 查询所有，排序
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return this.DoGetAll(sortPredicate, sortOrder);
        }
        /// <summary>
        /// 根据条件查询所有,排序
        /// </summary>
        /// <param name="expredicate"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return this.DoGetAll(expredicate, sortPredicate, sortOrder);
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        public PagedResult<TAggregateRoot> PagerQuery(Pager pager)
        {
            return this.DoPagerQuery(pager);
        }
        /// <summary>
        /// 查询分页,排序
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public PagedResult<TAggregateRoot> PagerQuery(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager)
        {
            return this.DoPagerQuery(sortPredicate, pager);
        }
        /// <summary>
        /// 查询分页，条件
        /// </summary>
        /// <param name="expredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public PagedResult<TAggregateRoot> PagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Pager pager)
        {
            return this.DoPagerQuery(expredicate, pager);
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="expredicate"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        public PagedResult<TAggregateRoot> PagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager)
        {
            return this.DoPagerQuery(expredicate, sortPredicate, pager);
        }

        #endregion

    }
    /// <summary>
    /// 默认Guid
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public abstract class Repository<TAggregateRoot> : Repository<Guid, TAggregateRoot>, IRepository<TAggregateRoot>
        where TAggregateRoot : class , IAggregateRoot
    {
        public Repository(IRepositoryContext context)
            : base(context)
        { }

    }
}
