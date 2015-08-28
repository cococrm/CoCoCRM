using System;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    /// <summary>
    /// 员工
    /// </summary>
    public class EmployeeRepository : EntityFrameworkRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IRepositoryContext context)
            : base(context)
        { }
    }
}
