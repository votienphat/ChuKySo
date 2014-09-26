using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public class AdapterCommon
    {
        /// <summary>
        /// Lớp chuyển từ 1 đối tượng ko xác định thành 1 đối tượng xác định dựa vào DisplayName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T FromDisplayName<T>(List<KeyValuePair<string, string>> list)
        {
            var type = typeof(T);

            var obj = Activator.CreateInstance(type, null);

            // Nếu list là null thì tạo list
            list = list ?? new List<KeyValuePair<string, string>>();

            if (list.Any())
            {
                // Set value for property
                PropertyInfo[] props = type.GetProperties();
                foreach (var propertyInfo in props)
                {
                    object[] attrs = propertyInfo.GetCustomAttributes(true);
                    if (attrs.OfType<DisplayNameAttribute>().Any())
                    {
                        var keyValuePair = list.Where(o => o.Key == ((DisplayNameAttribute)attrs[0]).DisplayName).ToList();
                        if (keyValuePair.Any())
                        {
                            object propertyValue;
                            switch (propertyInfo.PropertyType.Name)
                            {
                                case "Int16":
                                    Int16 i16Tmp;
                                    Int16.TryParse(keyValuePair.Single().Value, out i16Tmp);
                                    propertyValue = i16Tmp;
                                    break;
                                case "Int32":
                                    Int32 iTmp;
                                    Int32.TryParse(keyValuePair.Single().Value, out iTmp);
                                    propertyValue = iTmp;
                                    break;
                                case "Int64":
                                    Int64 lTmp;
                                    Int64.TryParse(keyValuePair.Single().Value, out lTmp);
                                    propertyValue = lTmp;
                                    break;
                                case "DateTime":
                                    DateTime dtTmp;
                                    DateTime.TryParse(keyValuePair.Single().Value, out dtTmp);
                                    propertyValue = dtTmp;
                                    break;
                                case "Decimal":
                                    Decimal dTmp;
                                    Decimal.TryParse(keyValuePair.Single().Value, out dTmp);
                                    propertyValue = dTmp;
                                    break;
                                case "Double":
                                    Double douTmp;
                                    Double.TryParse(keyValuePair.Single().Value, out douTmp);
                                    propertyValue = douTmp;
                                    break;
                                default:
                                    propertyValue = keyValuePair.Single().Value.Trim().ToLower() == "null" ? null : keyValuePair.Single().Value;
                                    break;
                            }

                            type.InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, obj,
                                  new[] { propertyValue });
                        }
                    }
                }
            }
            return (T)obj;
        }
    }
}
