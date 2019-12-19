using HPIT.Data.Core;
using Student.DAL.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{
    public class Fenye
    {
        public static Fenye Instance = new Fenye();
        public StudentDataModel1 Context { get; set; }
        public Fenye()
        {
            this.Context = new StudentDataModel1();
        }
        public object GetPageData(SearchModel<StudentInfo> search, out int count)
        {
            GetPageListParameter<StudentInfo, int> par = new GetPageListParameter<StudentInfo, int>();
            par.isAsc = true;
            par.orderByLambda = t => t.StudentID;
            par.pageIndex = search.PageIndex;
            par.pageSize = search.PageSize;
            par.whereLambda = t => t.StudentID != 0;
            StudentDataModel1 Instance = new StudentDataModel1();
            DBBaseService baseService = new DBBaseService(Instance);
            List<StudentInfo> list = baseService.GetSimplePagedData<StudentInfo, int>(par, out count);
            return list;
        }
        public int DeleteDic(int id)
        {
            return id;
        }

        public int UpdateDic(SearchModel<StudentInfo> search)
        {
            throw new NotImplementedException();
        }
        //public FenyeJsonResult UpdateDic(SearchModel<StudentInfo> search)
        //{
        //    int result = Fenye.Instance.UpdateDic(search);
        //    return new FenyeJsonResult(new { data = result, state = result });
        //}
    }
}
