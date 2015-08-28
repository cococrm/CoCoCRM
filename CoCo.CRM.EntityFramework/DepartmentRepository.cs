using System;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;

namespace CoCo.CRM.EntityFramework
{
    public class DepartmentRepository: EntityFrameworkRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IRepositoryContext context)
            : base(context)
        { }
    }
}
