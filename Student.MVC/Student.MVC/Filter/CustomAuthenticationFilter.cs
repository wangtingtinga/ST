using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using Newtonsoft.Json;
using System;
using Student.MVC.Common;
using HPIT.Data.Core;

namespace Student.MVC.Filters
{
    public class CustomAuthenticationFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //如果action 和 controller的添加的特性里面包含匿名的，则直接过滤掉。
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true))
            {
                return;
            }
            var Url = new UrlHelper(filterContext.RequestContext);
            var urlstr = Url.Action("Index", "Login");
            //filterContext.Result = new RedirectResult(urlstr); //指定返回重定向登录界面
            HttpCookie cokie = filterContext.HttpContext.Request.Cookies.Get("login");
            if (cokie == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                       {
                                           {"controller","Login"},
                                           {"action","Index"},
                                           {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                                       });
            }
            else
            {
                var value = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(cokie.Value));
                LogHelper.Default.WriteInfo(value + "登陆了系统");
                DeluxeStu.record = JsonConvert.DeserializeObject<Student.DAL.Entity.Record>(value);
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                       {
                                           {"controller","Login"},
                                           {"action","Index"},
                                           {"returnUrl",filterContext.HttpContext.Request.RawUrl }
                                       });
            }
        }
    }
}