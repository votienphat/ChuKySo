using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using Common.Model;
using Newtonsoft.Json;

namespace Common
{
    public class ObjectCommon
    {
        /// <summary>
        /// Đọc giá trị từ base class và chuyển sang sub class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="baseObject"></param>
        /// <returns></returns>
        public static T FromBase<T>(object baseObject)
        {
            var type = typeof(T);

            var obj = Activator.CreateInstance(type, null);

            // If base type is not RequestBase => do not anything and return null
            if (type.BaseType == null || type.BaseType != baseObject.GetType()) return (T)obj;

            var baseAttrs = baseObject.GetType().GetProperties();

            foreach (var propertyInfo in baseAttrs)
            {
                type.InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, obj,
                  new[] { propertyInfo.GetValue(baseObject, null) });
            }

            return (T)obj;
        }
    }
}
