using System;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    /// <summary>
    /// 岗位权限
    /// </summary>
    public class PostActionRepository: EntityFrameworkRepository<PostAction>, IPostActionRepository
    {
        public PostActionRepository(IRepositoryContext context)
            : base(context)
        { }
    }
}
