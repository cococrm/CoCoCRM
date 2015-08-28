using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CoCo.CRM.Infrastructure;

namespace CoCo.CRM.Domain.Repositories
{
    public interface IRepository<TKey, TAggregateRoot>
            where TAggregateRoot : class,IAggregateRoot<TKey>
    {
        #region 属性
        /// <summary>
        /// 获取当前仓储所使用的仓储上下文实例。
        /// </summary>
        IRepositoryContext Context { get; }
        #endregion

        #region 方法
        /// <summary>
        /// 将指定的聚合根添加到仓储中。
        /// </summary>
        /// <param name="aggregateRoot">需要添加到仓储的聚合根实例。</param>
        void Add(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="aggreateRoots"></param>
        void Add(IEnumerable<TAggregateRoot> aggreateRoots);
        /// <summary>
        /// 将指定的聚合根从仓储中移除。
        /// </summary>
        /// <param name="aggregateRoot">需要从仓储中移除的聚合根。</param>
        void Remove(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 批量移除
        /// </summary>
        /// <param name="aggreateRoots"></param>
        void Remove(IEnumerable<TAggregateRoot> aggreateRoots);
        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="key"></param>
        void Remove(TKey key);
        /// <summary>
        /// 根据主键结合移除
        /// </summary>
        /// <param name="keys"></param>
        void Remove(IEnumerable<TKey> keys);
        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="expredicate"></param>
        void Remove(Expression<Func<TAggregateRoot, bool>> expredicate); 
        /// <summary>
        /// 更新指定的聚合根。
        /// </summary>
        /// <param name="aggregateRoot">需要更新的聚合根。</param>
        void Update(TAggregateRoot aggregateRoot);
        /// <summary>
        /// 判定是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Exists(TKey key);
        /// <summary>
        /// 根据条件判定是否存在
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        bool Exists(Expression<Func<TAggregateRoot, bool>> expredicate);
        /// <summary>
        /// 根据聚合根的ID值，从仓储中读取聚合根。
        /// </summary>
        /// <param name="key">聚合根的ID值。</param>
        /// <returns>聚合根实例。</returns>
        TAggregateRoot GetByKey(TKey key);
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="expredicate">条件</param>
        /// <returns></returns>
        TAggregateRoot Single(Expression<Func<TAggregateRoot, bool>> expredicate);
        /// <summary>
        /// 从仓储中读取所有聚合根。
        /// </summary>
        /// <returns>所有的聚合根。</returns>
        IEnumerable<TAggregateRoot> GetAll();
        /// <summary>
        /// 根据条件查询对象
        /// </summary>
        /// <param name="expredicate"></param>
        /// <returns></returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expredicate);
        /// <summary>
        /// 以指定的排序字段和排序方式，从仓储中读取所有聚合根。
        /// </summary>
        /// <param name="sortPredicate">用于表述排序字段的Lambda表达式。</param>
        /// <param name="sortOrder">排序方式。</param>
        /// <returns>排序后的所有聚合根。</returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        /// <summary>
        /// 以指定的排序字段和排序方式，从仓储中读取所有聚合根。
        /// </summary>
        /// <param name="sortPredicate">用于表述排序字段的Lambda表达式。</param>
        /// <param name="sortOrder">排序方式。</param>
        /// <returns>排序后的所有聚合根。</returns>
        IEnumerable<TAggregateRoot> GetAll(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, SortOrder sortOrder);
        /// <summary>
        /// 以指定的排序字段和排序方式，以及分页参数，从仓储中读取所有聚合根。
        /// </summary>
        /// <param name="sortPredicate">用于表述排序字段的Lambda表达式。</param>
        /// <param name="sortOrder">排序方式。</param>
        /// <param name="pageNumber">分页的页码。</param>
        /// <param name="pageSize">分页的页面大小。</param>
        /// <returns>带有分页信息的聚合根集合。</returns>
        PagedResult<TAggregateRoot> PagerQuery(Pager pager);
        /// <summary>
        /// 以指定的排序字段和排序方式，以及分页参数，从仓储中读取所有聚合根。
        /// </summary>
        /// <param name="sortPredicate">用于表述排序字段的Lambda表达式。</param>
        /// <param name="sortOrder">排序方式。</param>
        /// <param name="pageNumber">分页的页码。</param>
        /// <param name="pageSize">分页的页面大小。</param>
        /// <returns>带有分页信息的聚合根集合。</returns>
        PagedResult<TAggregateRoot> PagerQuery(Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager);
        /// <summary>
        /// 以指定的排序字段和排序方式，以及分页参数，从仓储中读取所有聚合根。
        /// </summary>
        /// <param name="sortPredicate">用于表述排序字段的Lambda表达式。</param>
        /// <param name="sortOrder">排序方式。</param>
        /// <param name="pageNumber">分页的页码。</param>
        /// <param name="pageSize">分页的页面大小。</param>
        /// <returns>带有分页信息的聚合根集合。</returns>
        PagedResult<TAggregateRoot> PagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Pager pager);
        /// <summary>
        /// 以指定的排序字段和排序方式，以及分页参数，从仓储中读取所有聚合根。
        /// </summary>
        /// <param name="sortPredicate">用于表述排序字段的Lambda表达式。</param>
        /// <param name="sortOrder">排序方式。</param>
        /// <param name="pageNumber">分页的页码。</param>
        /// <param name="pageSize">分页的页面大小。</param>
        /// <returns>带有分页信息的聚合根集合。</returns>
        PagedResult<TAggregateRoot> PagerQuery(Expression<Func<TAggregateRoot, bool>> expredicate, Expression<Func<TAggregateRoot, dynamic>> sortPredicate, Pager pager);

        #endregion
    }
    /// <summary>
    /// 默认接口Tkey，Guid
    /// </summary>
    /// <typeparam name="TAggregateRoot"></typeparam>
    public interface IRepository<TAggregateRoot> : IRepository<Guid, TAggregateRoot>
        where TAggregateRoot : class ,IAggregateRoot
    { }
}
