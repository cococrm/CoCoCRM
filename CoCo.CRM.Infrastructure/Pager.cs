using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoCo.CRM.Infrastructure
{
    public class Pager
    {
        public Pager()
        {
            this.PageNumber = 1;
            this.PageSize = 20;
            Order = SortOrder.Ascending;
        }

        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="pageNumber">页索引，即第几页，从1开始</param> 
        public Pager(int pageNumber)
        {
            this.PageNumber = pageNumber;
            this.PageSize = 20;
            this.Order = SortOrder.Ascending;
        }

        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数,默认20</param> 
        /// <param name="order">排序条件</param>
        public Pager(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Order = SortOrder.Ascending;
        }

        /// <summary>
        /// 初始化分页
        /// </summary>
        /// <param name="page">页索引</param>
        /// <param name="pageSize">每页显示行数,默认20</param> 
        /// <param name="order">排序条件</param>
        public Pager(int pageNumber, int pageSize, SortOrder order)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Order = order;
        }

        /// <summary>
        /// 获取或设置页面大小
        /// </summary>
        public int PageSize { get; set; }
        private int _pageIndex;
        /// <summary>
        /// 页索引，即第几页，从1开始
        /// </summary>
        public int PageNumber
        {
            get
            {
                if (_pageIndex <= 0)
                    _pageIndex = 1;
                return _pageIndex;
            }
            set { _pageIndex = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public SortOrder Order { get; set; }
        /// <summary>
        /// 查询起始
        /// </summary>
        public int Skip
        {
            get
            {
                return PageSize * (PageNumber - 1);
            }
        }
    }
}
