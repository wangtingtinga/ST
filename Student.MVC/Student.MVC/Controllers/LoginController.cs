using Newtonsoft.Json;
using Student.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student.DAL;
using HPIT.Data.Core;

namespace Student.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        [AllowAnonymous]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        //public JsonResult LoginIn(string RecordID, string RecordPassword)
        //{
        //List<Record> users = Student.DAL.StudentDAL.Instance.LoginMember(RecordID, RecordPassword);
        //JsonResult jsonResult = new JsonResult();
        ////如果找到的话，就添加到缓存当中，并且跳转到主页面
        //if (users != null && users.Count >= 1)
        //{
        //    string json = JsonConvert.SerializeObject(users.FirstOrDefault());
        //    HttpCookie cokie = new HttpCookie("login", Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(json)));
        //    Response.Cookies.Add(cokie);
        //    jsonResult.Data = new { data = json, state = "200" };
        //    jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return jsonResult;
        //}
        //else
        //{
        //    jsonResult.Data = new { data = "未找到用户!", state = "403" };
        //    return jsonResult;
        //}
        //}
        public JsonResult GetJsonLogin(int id, string password)
        {
            Record record = LoginDAL.RecordLogin(id, password);
            JsonResult jsonResult = new JsonResult();
            if (record!=null)
            {
                 LogHelper.Default.WriteInfo(id + "登陆了系统");
                //string json = JsonConvert.SerializeObject(record);
                jsonResult.Data = new { data = record, state = "200" };
                //jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return Json(jsonResult,JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0);
            }
        }
        public ActionResult LogOff()
        {
            Request.Cookies.Clear();
            Response.Cookies.Clear();
            return View("Index");
        }
    }
}