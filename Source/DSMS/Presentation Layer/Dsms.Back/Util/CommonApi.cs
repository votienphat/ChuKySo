using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;

namespace Dsms.Back.Util
{
    public class CommonApi
    {
        public static MediaTypeFormatter JsonFormat
        {
            get { return GlobalConfiguration.Configuration.Formatters.JsonFormatter; }
        }

        #region Parse data from request

        /// <summary>
        /// Read value in form and convert to RequestBase based on T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="form"></param>
        /// <returns></returns>
        public static T FormToRequest<T>(FormDataCollection form)
        {
            var type = typeof(T);

            var obj = Activator.CreateInstance(type, null);

            var lstForm = form != null ? form.ToList() : new List<KeyValuePair<string, string>>();

            if (lstForm.Any())
            {
                // Set value for property
                var props = type.GetProperties();
                foreach (var propertyInfo in props)
                {
                    var attrs = propertyInfo.GetCustomAttributes(true);
                    string name = !attrs.OfType<DisplayNameAttribute>().Any()
                        ? propertyInfo.Name
                        : ((DisplayNameAttribute) attrs[0]).DisplayName;
                    if (string.IsNullOrEmpty(name))
                    {
                        continue;
                    }
                    var keyValuePair = lstForm.Where(o => o.Key.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (!keyValuePair.Any()) continue;
                    object propertyValue = ConvertRequestValue(propertyInfo.PropertyType.Name, keyValuePair.Single().Value);
                    type.InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, obj, new[] { propertyValue });
                }
            }
            return (T)obj;
        }

        /// <summary>
        /// Read value in form and convert to RequestBase based on T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static T QueryStringToRequest<T>(HttpRequestMessage request)
        {
            var type = typeof(T);

            var obj = Activator.CreateInstance(type, null);

            var queryStrings = request.RequestUri.ParseQueryString();

            // Set value for property
            var props = type.GetProperties();
            foreach (var propertyInfo in props)
            {
                string name = propertyInfo.Name;

                var attrs = propertyInfo.GetCustomAttributes(true);
                if (attrs.OfType<DisplayNameAttribute>().Any())
                {
                    name = ((DisplayNameAttribute)attrs[0]).DisplayName;
                }

                var value = queryStrings.Get(name);
                if (string.IsNullOrEmpty(value)) continue;
                object propertyValue = ConvertRequestValue(propertyInfo.PropertyType.Name, value);
                type.InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, obj, new[] { propertyValue });
            }
            return (T)obj;
        }

        private static object ConvertRequestValue(string typeName, string value)
        {
            object propertyValue;
            switch (typeName)
            {
                case "Int32":
                    int tmp;
                    Int32.TryParse(value, out tmp);
                    propertyValue = tmp;
                    break;
                case "Int64":
                    long l;
                    Int64.TryParse(value, out l);
                    propertyValue = l;
                    break;
                case "DateTime":
                    DateTime dt;
                    DateTime.TryParse(value, out dt);
                    propertyValue = dt;
                    break;
                case "Decimal":
                    decimal dec;
                    Decimal.TryParse(value, out dec);
                    propertyValue = dec;
                    break;
                default:
                    propertyValue = value;
                    break;
            }
            return propertyValue;
        }

        #endregion
    }
}