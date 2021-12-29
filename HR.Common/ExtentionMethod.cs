using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using Newtonsoft.Json;

namespace HR
{
    public static class ExtentionMethods
    {

        #region User

        public static void AppendCookie(this IResponseCookies responseCookies, string key, string value)
        {
            responseCookies.Append(key, value, new CookieOptions()
            {
                Expires = DateTime.UtcNow.AddHours(3).AddYears(5),
                HttpOnly = true,
                Path = "/",
                //TODO please un comment the next line if y will use HTTPS
                // Secure = true
            });
        }

        #endregion

        #region Random Numbers
        public static int RandomNumber(this int number)
        {
            Random random = new Random((int)DateTime.UtcNow.AddHours(3).Ticks);
            return random.Next(1111111, 9999999);
        }
        #endregion


 

        /// <summary>
        /// Check If This Field Is Empty Or Null or "" or white space
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string s) => s == null || string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s);


        /// <summary>
        /// Check If This Field Is Empty Or Null or "" or white space
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty(this object s) => s == null || string.IsNullOrEmpty(s.ToString()) || string.IsNullOrWhiteSpace(s.ToString());

        #region Get Url , Action ,etc

        /// <summary>
        /// Get The Specified Action Followed By its Controller and Area if exists
        /// </summary>
        /// <param name="html">The Current Html Helper</param>
        /// <param name="action">The Required Action At Same Area</param>
        /// <returns></returns>
        public static string GetAction(this IUrlHelper html, string action)
        {
            string _url = "/";
            if (html.ActionContext.HttpContext.GetRouteValue("area") != null)
                _url += html.ActionContext.HttpContext.GetRouteValue("area").ToString() + "/";
            _url += html.ActionContext.HttpContext.GetRouteValue("controller").ToString() + "/";
            _url += action;
            return _url;
        }
        public static string GetAction(this IUrlHelper html, string action, string controller)
        {
            string _url = "/";
            if (html.ActionContext.HttpContext.GetRouteValue("area") != null)
                _url += html.ActionContext.HttpContext.GetRouteValue("area").ToString() + "/";
            _url += controller + "/";
            _url += action;
            return _url;
        }
        public static string GetAction(this IUrlHelper html, string action, string controller, string area)
        {
            string _url = "/";
            _url += area + "/";
            _url += controller + "/";
            _url += action;
            return _url;
        }

        public static string GetAction(this IUrlHelper html, string action, string controller, string area, string route)
        {
            string _url = "/";
            _url += area + "/";
            _url += controller + "/";
            _url += action + "/";
            _url += route;
            return _url;
        }


        public static string GetFullUrl(this IUrlHelper url, string fileName = "")
        {
            var request = url.ActionContext.HttpContext.Request;
            string FullUrl = $"{request.Scheme}://{request.Host}/{fileName}";

            return FullUrl;
        }


        public static string GetFormKeyString(this HttpContext httpContext)
        {
            string area = httpContext.GetRouteValue("area")?.ToString() ?? "";
            string controller = httpContext.GetRouteValue("controller").ToString();
            return area == "" ? string.Concat("", controller, ".")
                : string.Concat(area, ".", controller, ".");
        }

        #endregion

        /// <summary>
        /// Serialize Any C# <see cref="object"/> <see cref="class"/> , <see cref="IEnumerable"/> ,... etc to json object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(this object obj) => JsonConvert.SerializeObject(obj);

        public static T Desrialize<T>(this string obj) => JsonConvert.DeserializeObject<T>(obj);

        public static string GetIdOfObjReflection(this object obj)
        {
            var typ = obj.GetType();
            var id = typ.GetProperty("ID");
            if (id == null) id = typ.GetProperty("Id");

            return id?.GetValue(obj)?.ToString();
        }

        /// <summary>
        /// convert string to long if it is a valid number else return <see cref="default"/>
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static long AsLong(this string s)
        {
            if (!s.IsEmpty() && long.TryParse(s, out long l))
            {
                return l;
            }
            return default;
        }

        public static string GetArrayAsString(this long[] ids)
           => ids == null ? null : ids.Select(x => x.ToString()).Aggregate((a, b) => a + "," + b);


        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            return (type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att) ? valueSelector(att) : default;
        }



  

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        /// <summary>
        /// If All Properties inside this object is null or empty or ....
        /// </summary>
        /// <param name="mdl">any c# <see cref="object"/></param>
        /// <param name="EmptyValues">Default is <see cref="null"/>,<see cref="Guid.Empty"/> <see cref="string.Empty"/> </param>
        /// <returns></returns>
        public static bool IsValid(this object mdl, object[] EmptyValues = null, IEnumerable<string> exceptProperties = null)
        {
            var data = mdl.GetType().GetProperties().AsEnumerable();
            if (exceptProperties != null)
            {
                data = data.Where(x => !exceptProperties.Contains(x.Name));
            }
            return (data.Where(x => EmptyValues.Any(y => y == x.GetValue(mdl)))?.Count() ?? 0) == 0;
        }


        public static string AsString(this DateTime date, string format = "MM-dd-yyyy")
            => date.ToString(format);

        public static string UpperFirstLetter(this string s, string separator = "")
        {
            if (s.IsEmpty()) return "";

            if (separator == "")
            {
                return s.Substring(0, 1).ToUpper() + s[1..].ToLower();
            }

            return separator + s.Split(separator).Skip(1).Select(x => x.Substring(0, 1).ToUpper() + x.Substring(1).ToLower()).Aggregate((a, b) => a + separator + b);
        }

        public static string RemoveLines(this string s)
        {
            if (s == null) return "";
            return s.Replace("\r", "").Replace("\n", "").Replace(Environment.NewLine, "").TrimStart().TrimEnd();
        }


        /// <summary>
        /// Generate a unique number depending on date time
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string UniqueNumber(this object obj)
        {
            var date = DateTime.UtcNow.AddHours(3);
            var dateString = date.Year + "" + date.Month + "" + date.Day + "" +
                (date.Millisecond.ToString().Length == 3 ? date.Millisecond.ToString().Substring(0, 2) : date.Millisecond + "");
            string res= dateString + (new Random()).Next(1, 1000); 
            return res;
        }


        #region Api

        public static long GetUserId(this IEnumerable<Claim> enumerable)
        {
            if (enumerable != default && enumerable.Count() > 0)
            {
                var claim = enumerable.FirstOrDefault(x => x.Type == ClaimTypes.Name);
                if (claim != default)
                {
                    if (long.TryParse(claim.Value, out long c))
                    {
                        return c;
                    }
                }
            }
            return default;
        }

        #endregion

      


    }

}
