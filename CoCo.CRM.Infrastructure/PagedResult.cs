using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoCo.CRM.Infrastructure
{
    /// <summary>
    /// 分页返回集合
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T> : ICollection<T>, IEnumerable<T>
    {
        /// <summary>
        /// 设置空数据
        /// </summary>
        //public readonly PagedResult<T> Empty = new PagedResult<T>(0, 0, 0, null);

        #region 构造函数
        /// <summary>
        /// 初始化构造函数
        /// </summary>
        public PagedResult()
        {
            Data = new List<T>();
        }
        /// <summary>
        /// 初始化构造函数
        /// </summary>
        /// <param name="totalPages">总页数</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNumber">页码</param>
        /// <param name="data">页面数据</param>
        public PagedResult(int pageSize, int pageNumber, List<T> data)
        {
            this.PageSize = PageSize;
            this.PageNumber = pageNumber;
            this.Data = data;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取总记录数
        /// </summary>
        public int TotalRecords { get { return Data.Count; } }
        /// <summary>
        /// 获取或者设置总页数
        /// </summary>
        public int TotalPages
        {
            get
            {
                if (TotalRecords == 0)
                    return 0;
                if ((TotalRecords % PageSize) == 0)
                    return TotalRecords / PageSize;
                return (TotalRecords / PageSize) + 1;
            }

        }
        /// <summary>
        /// 获取或设置页面大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 获取或设置当前页码
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 获取当前页面数据
        /// </summary>
        public List<T> Data { get; set; }
        #endregion

        #region 重写方法
        /// <summary>
        /// 重新相等判定方法
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            if (obj == (object)null)
                return false;
            var other = obj as PagedResult<T>;
            if (other == (object)null)
                return false;
            return this.TotalPages == other.TotalPages &&
                this.TotalRecords == other.TotalRecords &&
                this.PageNumber == other.PageNumber &&
                this.PageSize == other.PageSize &&
                this.Data == other.Data;
        }

        /// <summary>
        /// 用作特定类型的哈希函数。
        /// </summary>
        /// <returns>当前Object的哈希代码。</returns>
        /// <remarks>有关此函数的更多信息，请参见：http://msdn.microsoft.com/zh-cn/library/system.object.gethashcode。
        /// </remarks>
        public override int GetHashCode()
        {
            return this.TotalPages.GetHashCode() ^
                this.TotalRecords.GetHashCode() ^
                this.PageNumber.GetHashCode() ^
                this.PageSize.GetHashCode();
        }

        /// <summary>
        /// 确定两个对象是否相等。
        /// </summary>
        /// <param name="a">待确定的第一个对象。</param>
        /// <param name="b">待确定的另一个对象。</param>
        /// <returns>如果两者相等，则返回true，否则返回false。</returns>
        public static bool operator ==(PagedResult<T> a, PagedResult<T> b)
        {
            if (ReferenceEquals(a, b))
                return true;
            if ((object)a == null || (object)b == null)
                return false;
            return a.Equals(b);
        }

        /// <summary>
        /// 确定两个对象是否不相等。
        /// </summary>
        /// <param name="a">待确定的第一个对象。</param>
        /// <param name="b">待确定的另一个对象。</param>
        /// <returns>如果两者不相等，则返回true，否则返回false。</returns>
        public static bool operator !=(PagedResult<T> a, PagedResult<T> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举数。
        /// </summary>
        /// <returns>一个可用于循环访问集合的 IEnumerator 对象。</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        /// <summary>
        /// 返回一个循环访问集合的枚举数。 （继承自 IEnumerable。）
        /// </summary>
        /// <returns>一个可用于循环访问集合的 IEnumerator 对象。</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        #region ICollection<T> Members
        /// <summary>
        /// 将某项添加到 ICollection{T} 中。
        /// </summary>
        /// <param name="item">要添加到 ICollection{T} 的对象。</param>
        public void Add(T item)
        {
            Data.Add(item);
        }

        /// <summary>
        /// 从 ICollection{T} 中移除所有项。
        /// </summary>
        public void Clear()
        {
            Data.Clear();
        }

        /// <summary>
        /// 确定 ICollection{T} 是否包含特定值。
        /// </summary>
        /// <param name="item">要在 ICollection{T} 中定位的对象。</param>
        /// <returns>如果在 ICollection{T} 中找到 item，则为 true；否则为 false。</returns>
        public bool Contains(T item)
        {
            return Data.Contains(item);
        }

        /// <summary>
        /// 从特定的 Array 索引开始，将 ICollection{T} 的元素复制到一个 Array 中。
        /// </summary>
        /// <param name="array">作为从 ICollection{T} 复制的元素的目标的一维 Array。 Array 必须具有从零开始的索引。</param>
        /// <param name="arrayIndex">array 中从零开始的索引，从此索引处开始进行复制。</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 获取 ICollection{T} 中包含的元素数。
        /// </summary>
        public int Count
        {
            get { return Data.Count; }
        }

        /// <summary>
        /// 获取一个值，该值指示 ICollection{T} 是否为只读。
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// 从 ICollection{T} 中移除特定对象的第一个匹配项。
        /// </summary>
        /// <param name="item">要从 ICollection{T} 中移除的对象。</param>
        /// <returns>如果已从 ICollection{T} 中成功移除 item，则为 true；否则为 false。 如果在原始 ICollection{T} 中没有找到 item，该方法也会返回 false。 </returns>
        public bool Remove(T item)
        {
            return Data.Remove(item);
        }

        #endregion
        #endregion
    }
}
