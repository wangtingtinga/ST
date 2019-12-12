using HPIT.Data.Core;
using Student.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{
    public class LoginDAL
    {

        //public List<Record> LoginMember(int loginId, string passWord)
        //{
        //    string sql = "select * from Record where RecordID=? and RecordPassword=?";
        //    Record records = new Record();
        //    records.RecordID = loginId;
        //    records.RecordPassword = passWord;
        //    LogHelper.Default.WriteInfo(records.RecordID+"---"+records.RecordPassword);
        //    List<Record> result = DBHelper.ExecuteReader<Record>(sql, records).ToString();
        //    return result;
        //}
        public static Record RecordLogin(int studentid, string password)
        {
            StudentDataModel1 studentDataModel1 = new StudentDataModel1();
            List<Record> records = studentDataModel1.Record.ToList();
            Record recorda = records.FirstOrDefault(p => p.StudentID == studentid && p.RecordPassword== password);
            return recorda;
        }
    }
}
