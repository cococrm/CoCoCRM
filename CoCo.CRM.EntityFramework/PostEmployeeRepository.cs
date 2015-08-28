using System;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    /// <summary>
    /// 部门员工关系对应
    /// </summary>
    public class PostEmployeeRepository : EntityFrameworkRepository<PostEmployee>, IPostEmployeeRepository
    {
        public PostEmployeeRepository(IRepositoryContext context)
            : base(context)
        {

        }
    }
}
