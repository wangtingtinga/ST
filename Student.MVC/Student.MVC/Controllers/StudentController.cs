using Student.DAL;
using Student.DAL.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace Student.MVC.Controllers
{
    public class StudentController : Controller
    {
        StudentDAL dal = new StudentDAL();
        // GET: Student
        public ActionResult Index()
        {
            List<StudentInfo> studentInfos = dal.GetStudentList();
            return View(studentInfos);
        }
        public ActionResult Create()
        {
            //List<SelectListItem> selects = new List<SelectListItem>();
            //foreach (var item in dal.GetMajors())
            //{
            //    SelectListItem ll = new SelectListItem();
            //    ll.Text = item.MajorName;
            //    ll.Value = item.MajorID.ToString();
            //    selects.Add(ll);
            //}
            ViewBag.MajorName = dal.GetMajors().Select(major => new SelectListItem() { Text = major.MajorName, Value = major.MajorID.ToString() }).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CreateModal(StudentInfo studentInfo)
        {
            //1.插入dal用户数据
            if (dal.AddStudent(studentInfo) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
        }
        public ActionResult Edit(int id)
        {
            StudentInfo studentInfo = dal.GetStudentById(id);
            ViewBag.MajorName = dal.GetMajors().Select(major => new SelectListItem() { Text = major.MajorName, Value = major.MajorID.ToString() }).ToList();
            return View(studentInfo);
        }

        public ActionResult StudentModal(StudentInfo studentInfo)
        {
            if (dal.EditStudentInfo(studentInfo) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");
            }
        }
        public ActionResult Delete(int id)
        {
            if (dal.DeleteStudent(id) > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Delete");
            }
        }

        //public ActionResult Details(int id)
        //{
        //    if (dal.DetailsStudent(id) > 0)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Details");
        //    }
        //}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentDataModel1 db = new StudentDataModel1();
            StudentInfo studentInfo = db.StudentInfo.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }
    }
}