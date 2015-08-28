﻿using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;
using CoCo.CRM.Common;

namespace CoCo.CRM.Infrastructure
{
    /// <summary>
    /// 表示用于异常日志记录的拦截行为。
    /// </summary>
    public class ExceptionLoggingBehavior : IInterceptionBehavior
    {
        #region IInterceptionBehavior Members

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var methodReturn = getNext().Invoke(input, getNext);
            if (methodReturn.Exception != null)
            {
                Log.Error(methodReturn.Exception);
            }
            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }

        #endregion
    }
}
