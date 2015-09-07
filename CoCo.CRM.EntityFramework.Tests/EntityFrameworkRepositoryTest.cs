using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoCo.CRM.Domain.Repositories;
using CoCo.CRM.Domain.Entity;
using CoCo.CRM.EntityFramework;

namespace CoCo.CRM.EntityFramework.Tests
{
    [TestClass]
    public class EntityFrameworkRepositoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRepositoryContext repositoryContext = new EntityFrameworkRepositoryContext();
            ISysMenuRepository repository = new SysMenuRepository(repositoryContext);
            IList<SysMenu> list = new List<SysMenu>();
            SysMenu menu = new SysMenu();
            menu.ID = new Guid("4AF143A1-29CC-D043-DA49-FAA926ABA470");
            menu.MenuName = "aa";
            list.Add(menu);

            //repository.Remove(list);

            var _list = repository.GetAll(o => o.ID.Equals(menu.ID));
            repository.Remove(_list);
            repository.Context.Commit();
        }
    }
}
