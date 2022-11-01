
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using HR.Static;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

using Newtonsoft.Json;

namespace HR.Common
{
    /// <summary>
    /// This Class Is Responsible for all extenstion method in the app
    /// we removed Common from Electricity.Common namespace to make this class public 
    /// for the all application
    /// </summary>
    public static class ExtentionMethods
    {

        #region User

        public static void AppendCookie(this IResponseCookies responseCookies, string key, string value)
        {
            responseCookies.Append(key, value, new CookieOptions()
            {
                Expires = DateTime.UtcNow.AddHours(HourServer.hours).AddYears(5),
                HttpOnly = true,
                Path = "/",
                //TODO please un comment the next line if y will use HTTPS
                // Secure = true
            });
        }

        

        #endregion


        public static bool IsNumber(this string x)
        {
            string strRegex = @"^\d$";

            
            Regex re = new Regex(strRegex);


            if (re.IsMatch(x))
                return (true);
            else
                return (false);
        }

        public static decimal RoundNumber(this decimal? num)
            =>num.HasValue? Math.Round(num.Value, 4):0;
        public static string GetFullName(this HttpRequest request)
        {
            return request.Cookies.ContainsKey(AppConstant.Cookies.UserFullNameCookie) ? request.Cookies[AppConstant.Cookies.UserFullNameCookie] : "";
        }

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


        #endregion

        /// <summary>
        /// Serialize Any C# <see cref="object"/> <see cref="class"/> , <see cref="IEnumerable"/> ,... etc to json object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(this object obj) =>
            JsonConvert.SerializeObject(obj);

        public static T Desrialize<T>(this string obj) => JsonConvert.DeserializeObject<T>(obj);


        public static string GetArrayAsString(this long[] ids)
           => ids == null || ids.Length == 0 ? null : ids.Select(x => x.ToString()).Aggregate((a, b) => a + "," + b);

        public static bool IsValid(this object mdl, object[] EmptyValues = null, IEnumerable<string> exceptProperties = null)
        {
            EmptyValues ??= AppConstant.EmptyValues;

            var data = mdl.GetType().GetProperties().AsEnumerable();
            if (exceptProperties != null)
            {
                data = data.Where(x => !exceptProperties.Contains(x.Name));
            }
            return (data.Where(x => EmptyValues.Any(y => y == x.GetValue(mdl)))?.Count() ?? 0) == 0;
        }

        public static string GetArrayAsString(this string[] ids)
           => ids == null || ids.Length == 0 ? null : ids.Where(x => x != null).Select(x => x.ToString()).Aggregate((a, b) => a + "," + b);


        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector) where TAttribute : Attribute
        {
            return (type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() is TAttribute att) ? valueSelector(att) : default;
        }




        public static bool IsAjaxRequest(this HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }


        public static string GetAttributeDisplayName(this PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) return "";

            var attribute = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
            return attribute?.DisplayName ?? propertyInfo.Name;
        }


    }
}
