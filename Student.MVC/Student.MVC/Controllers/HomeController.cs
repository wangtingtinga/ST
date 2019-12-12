using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HPIT.Data.Core;
using Student.DAL;
using Student.DAL.Entity;
using Student.MVC.Filters;

namespace Student.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public FenyeJsonResult QueryPageData(SearchModel<StudentInfo> search)
        {
            int total = 0;
            var result = Student.DAL.Fenye.Instance.GetPageData(search, out total);
            var totalPages = total % search.PageSize == 0 ? total / search.PageSize : total / search.PageSize + 1;
            return new FenyeJsonResult(new { Data = result, Total = total, TotalPages = totalPages }, "yyyy-MM-dd HH: mm");
        }

    }
}