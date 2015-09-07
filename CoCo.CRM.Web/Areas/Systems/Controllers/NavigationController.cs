using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using CoCo.CRM.Application;
using CoCo.CRM.Application.Impl;
using CoCo.CRM.Infrastructure;
using CoCo.CRM.ModelDTO;
using CoCo.CRM.Common;

namespace CoCo.CRM.Web.Areas.Systems.Controllers
{
    /// <summary>
    /// 导航菜单
    /// </summary>
    public class NavigationController : ControllerBase
    {
        private readonly ISysMenuService _sysMenuService = ServiceLocator.Instance.GetService<ISysMenuService>();

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 获取所有导航
        /// </summary>
        /// <returns></returns>
        public ActionResult Query()
        {
            var _list = _sysMenuService.GetAllMenuTree();
            return Content(Common.Json.ToJson(_list));
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="addList"></param>
        /// <param name="updateList"></param>
        /// <param name="deleteList"></param>
        /// <returns></returns>
        public ActionResult Save(string addList, string updateList, string deleteList)
        {
            IList<SysMenuDTO> addEntitys = Common.Json.ToObject<List<SysMenuDTO>>(addList);//添加
            IList<SysMenuDTO> updateEntitys = Common.Json.ToObject<List<SysMenuDTO>>(updateList);//修改
            IList<SysMenuDTO> deleteEntitys = Common.Json.ToObject<List<SysMenuDTO>>(deleteList);//删除
            _sysMenuService.Save(addEntitys, updateEntitys, deleteEntitys);
            return OK();
        }
        /// <summary>
        /// 创建一个新行
        /// </summary>
        /// <returns></returns>
        public ActionResult New()
        {
            var entity = new { ID = Guid.NewGuid(), ParentId = Guid.Empty, SortId = 99, isNewRecord = true };
            return Content(Common.Json.ToJson(entity));
        }
        /// <summary>
        /// 获取所以菜单返回ComboTree格式
        /// </summary>
        /// <returns></returns>
        public ActionResult GetComboTree()
        {
            var _plist = _sysMenuService.LoadSystemParent();
            var query = from p in _plist
                        select new TreeNode
                        {
                            Id = p.Id,
                            Text = p.Text,
                            IconCls = p.IconCls,
                            Children = _sysMenuService.LoadSystemMenuChilds(p.Id).ToList()
                        };
            var result = query.ToList();
            result.Insert(0, new TreeNode(Guid.Empty, "无父目录", ""));//加入 无父目录
            return Content(Common.Json.ToJson(result));
        }

    }
}
