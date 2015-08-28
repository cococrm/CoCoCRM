using System;
using System.Data.Entity;

namespace CoCo.CRM.Domain.Entity
{
    public class PostEmployee : AggregateRoot
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public Guid PostId { get; set; }
        /// <summary>
        /// 员工ID
        /// </summary>
        public Guid EmployeeId { get; set; }

        public PostEmployee(Guid postId, Guid employeeId)
        {
            this.PostId = postId;
            this.EmployeeId = employeeId;
        }
    }
}
