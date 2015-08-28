using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoCo.CRM.Common
{
    public static class Log
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("CoCo.CRM.Logger");

        /// <summary>
        /// 一般信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Info(string msg)
        {
            log.Info("[Info] ： " + msg);
        }

        /// <summary>
        /// Debug信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Debug(string msg)
        {
            log.Debug("[Debug]： " + msg);
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(string msg)
        {
            log.Error("[Error]： " + msg);
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Error(Exception exception)
        {
            log.Error("[Error]： ", exception);
        }

        /// <summary>
        /// 警告信息
        /// </summary>
        /// <param name="msg"></param>
        public static void Warn(string msg)
        {
            log.Warn("[Warn] ： " + msg);
        }
    }
}
