using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using CoCo.CRM.Domain;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.EntityFramework
{
    public class EntityFrameworkRepository<TKey, TAggregateRoot> : Repository<TKey, TAggregateRoot>
       where TAggregateRoot : class ,IAggregateRoot<TKey>
    {
        private readonly IEntityFrameworkRepositoryContext efContext;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context)
        {
            if (context is IEntityFrameworkRepositoryContext)
                this.efContext = context as IEntityFrameworkRepositoryContext;
        }

        /// <summary>
        /// 
        /// </summary>
        protected IEntityFrameworkRepositoryContext EFContext
        {
            get { return this.efContext; }
        }

        #region 重写方法，实现具体操作
        /// <summary>
        /// 重写父类方法，添加
        /// </summary>
        /// <param name="aggregateRoot"></param>
        protected override void DoAdd(TAggregateRoot aggregateRoot)
        {
            //this.efContext.Context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Added;
            this.efContext.Context.Set<TAggregateRoot>().Add(aggregateRoot);
            this.efContext.Committed = false;
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="aggreateRoots"></param>
        protected override void DoAdd(IEnumerable<TAggregateRoot> aggreateRoots)
        {
            this.efContext.Context.Set<TAggregateRoot>().AddRange(aggreateRoots);
            this.efContext.Committed = false;
        }
        /// <summary>
        /// 重写父类方法，修改
        /// </summary>
        /// <param name="aggregateRoot"></param>
        protected override void DoUpdate(TAggregateRoot aggregateRoot)
        {
            this.efContext.Context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Modified;
            efContext.Committed = false;
        }
        /// <summary>
        /// 重写父类方法，删除
        /// </summary>
        /// <param name="aggregateRoot"></param>
        protected override void DoRemove(TAggregateRoot aggregateRoot)
        {
            this.efContext.Context.Entry(aggregateRoot).State = System.Data.Entity.EntityState.Deleted;
            efContext.Committed = false;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="aggreateRoots"></param>
        protected override void DoRemove(IEnumerable<TAggregateRoot> aggreateRoots)
        {
            if (aggreateRoots == null)
                return;
            var list = aggreateRoots.ToList();
            if (!list.Any())
                return;
            this.efContext.Context.Set<TAggregateRoot>().RemoveRange(list);
            this.efContext.Committed = false;
        }
        /// <summary>
        /// 根据主键移除
        /// </summary>
        /// <param name="key"></param>
        protected override void DoRemove(TKey key)
        {
            var aggreateRoot = GetByKey(key);
            if (aggreateRoot == null)
                return;
            this.DoRemove(aggreateRoot);
        }
        /// <summary>
        /// 根据主键批量删除
        /// </summary>
        /// <param name="keys"></param>
        protected override void DoRemove(IEnumerable<TKey> keys)
        {
            if (keys == null)
                return;
            var list = this.DoGetAll(t => keys.Contains(t.ID));
            this.DoRemove(list);
        }
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="expredicate"></param>
        protected override void DoRemove(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            var aggreateRoots = this.efContext.Context.Set<TAggregateRoot>().Where(expredicate);
            this.DoRemove(aggreateRoots);
        }
        /// <summary>
        /// 根据主键判定是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override bool DoExists(TKey key)
        {
            var entity = GetByKey(key);
            if (entity == null)
                return false;
            return true;
        }
        /// <summary>
        /// 根据条件判定是否存在
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        protected override bool DoExists(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            return DoGetAll(expredicate).Any();
        }
        /// <summary>
        /// 重写父类方法，根据Key查询
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected override TAggregateRoot DoGetByKey(TKey key)
        {
            return efContext.Context.Set<TAggregateRoot>().Find(key);
        }
        /// <summary>
        /// 根据条件查询单条记录
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        protected override TAggregateRoot DoSingle(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            return DoGetAll(expredicate).First();
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<TAggregateRoot> DoGetAll()
        {
            return DoGetAll(null);
        }
        /// <summary>
        /// 根据条件查询对象
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        protected override IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, bool>> expredicate)
        {
            return DoGetAll(expredicate, null, SortOrder.Unspecified);
        }
        /// <summary>
        /// 查询所有排序
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        protected override IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            return DoGetAll(null, sortPredicate, sortOrder);
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <param name="expredicate"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        protected override IEnumerable<TAggregateRoot> DoGetAll(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder)
        {
            if (expredicate == null)
                expredicate = (o => true);
            var query = efContext.Context.Set<TAggregateRoot>()
                .Where(expredicate);
            if (sortPredicate != null)
            {
                switch (sortOrder)
                {
                    case SortOrder.Ascending:
                        return query.SortBy<TKey, TAggregateRoot>(sortPredicate).ToList();
                    case SortOrder.Descending:
                        return query.SortByDescending<TKey, TAggregateRoot>(sortPredicate).ToList();
                    default:
                        break;
                }
            }
            return query.ToList();
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected override PagedResult<TAggregateRoot> DoPagerQuery(Pager pager)
        {
            return DoPagerQuery(null, null, pager);
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="expredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected override PagedResult<TAggregateRoot> DoPagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Pager pager)
        {
            return DoPagerQuery(expredicate, null, pager);
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="sortPredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected override PagedResult<TAggregateRoot> DoPagerQuery(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager)
        {
            return DoPagerQuery(null, sortPredicate, pager);
        }
        /// <summary>
        /// 查询分页
        /// </summary>
        /// <param name="expredicate"></param>
        /// <param name="sortPredicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        protected override PagedResult<TAggregateRoot> DoPagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager)
        {
            if (expredicate == null)
                expredicate = (o => true);
            var query = efContext.Context.Set<TAggregateRoot>()
                .Where(expredicate);
            if (sortPredicate == null)
                sortPredicate = (o => o.ID);
            switch (pager.Order)
            {
                case SortOrder.Ascending:
                    var pagedGroupAscending = query.SortBy<TKey, TAggregateRoot>(sortPredicate).Skip(pager.Skip).Take(pager.PageSize).ToList();
                    if (pagedGroupAscending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pager.PageSize, pager.PageNumber, pagedGroupAscending);
                case SortOrder.Descending:
                    var pagedGroupDescending = query.SortByDescending<TKey, TAggregateRoot>(sortPredicate).Skip(pager.Skip).Take(pager.PageSize).GroupBy(p => new { Total = query.Count() }).FirstOrDefault();
                    if (pagedGroupDescending == null)
                        return null;
                    return new PagedResult<TAggregateRoot>(pager.PageSize, pager.PageNumber, pagedGroupDescending.Select(p => p).ToList());
                default:
                    break;
            }
            throw new InvalidOperationException("查询分页错误，检查参数是否正确！");
        }

        #endregion
    }

    public class EntityFrameworkRepository<TAggregateRoot> : EntityFrameworkRepository<Guid, TAggregateRoot>
        where TAggregateRoot : class ,IAggregateRoot
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public EntityFrameworkRepository(IRepositoryContext context)
            : base(context) { }
    }
}
