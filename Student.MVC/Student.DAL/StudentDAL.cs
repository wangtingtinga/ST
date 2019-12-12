using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student.DAL;
using Student.DAL.Entity;

namespace Student.DAL
{
    public class StudentDAL
    {
        StudentDataModel1 db = new StudentDataModel1();

        public List<StudentInfo> GetStudentList()
        {       
            List<StudentInfo> result = db.StudentInfo.ToList();
            return result;
        }
        public int AddStudent(StudentInfo studentInfo)
        {
            db.StudentInfo.Add(studentInfo);
            return db.SaveChanges();
        }
        public StudentInfo GetStudentById(int id)
        {
            return db.StudentInfo.FirstOrDefault(r => r.StudentID == id);
        }
        public int EditStudentInfo(StudentInfo studentInfo)
        {       
            //设置实体的状态为修改状态
            db.Entry(studentInfo).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        public List<Major> GetMajors()
        {
            return db.Major.ToList();
        }
        public int DeleteStudent(int id)
        {
            StudentInfo studentInfo = db.StudentInfo.Find(id);
            db.StudentInfo.Remove(studentInfo);
            return db.SaveChanges();
        }
    }
}
