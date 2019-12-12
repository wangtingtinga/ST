using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DAL
{
    public class DBHelper
    {
        public static string strCon = ConfigurationManager.ConnectionStrings["connectionStrings"].ConnectionString;
        /// <summary>
        /// 查询一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static object ExcuteScalar(string sql, params SqlParameter[] sqlParameters)
        {
            //创建链接
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                //执行链接
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //                    
                    cmd.Parameters.AddRange(sqlParameters);
                    return cmd.ExecuteScalar();
                }
            }
        }
        /// <summary>
        /// 查询多条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] sqlParameters)
        {
            //创建链接
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            //执行链接
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(sqlParameters);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }  
        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static int EcecuteSqlNonQuery(string sql, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection con = new SqlConnection(strCon))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddRange(sqlParameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        //public static int ExcuteSqlNonQuery(string sql, SqlParameter[] sqlParameters)
        //{
        //    //创建连接
        //    using (SqlConnection connection = new SqlConnection(connStr))
        //    {
        //        //创建命令
        //        using (SqlCommand command = new SqlCommand(sql, connection))
        //        {
        //            //判断连接是否打开，如果连接是关闭状态，则需要打开连接
        //            if (connection.State == ConnectionState.Closed)
        //            {
        //                connection.Open();
        //            }
        //            //添加参数
        //            command.Parameters.AddRange(sqlParameters);
        //            //返回结果,及时关闭掉连接
        //            return command.ExecuteNonQuery();
        //        }
        //  }
        //}
    }
}
