using System;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    /// <summary>
    /// 岗位
    /// </summary>
    public class PostRepository : EntityFrameworkRepository<Post>, IPostRepository
    {
        public PostRepository(IRepositoryContext context)
            : base(context)
        { }
    }
}
