using System;
using System.Data;
using System.Configuration;
using System.Data.OleDb;

namespace WebAPI
{
    /**//// <summary>
    /// DataAccess 的摘要说明
    /// </summary>
    public class DataAccess
    {
        protected static OleDbConnection Conn = new OleDbConnection();
        protected static OleDbCommand Comm = new OleDbCommand();  
        /**//// <summary>
        /// 打开数据库
        /// </summary>
        private static void OpenConnection(string dbname)
        {
            if (Conn.State == ConnectionState.Closed)
            { 
                switch (dbname)
                {
                    case "api/":
                    Conn.ConnectionString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConfigurationManager.AppSettings["myconn1"];//web.config文件里设定。   
                        break;
                    case "api2/":
                        Conn.ConnectionString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConfigurationManager.AppSettings["myconn2"];//web.config文件里设定。   
                        break;
                }
                ;


                Comm.Connection = Conn;
                try
                {
                    Conn.Open();
                }
                catch (Exception e)
                { throw new Exception(e.Message); }
            }
        }
        /**//// <summary>
        /// 关闭数据库
        /// </summary>
        private static void CloseConnection()
        {
            if (Conn.State == ConnectionState.Open)
            {
                Conn.Close();
                Conn.Dispose();
                Comm.Dispose();
            }
        }
        /**//// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sqlstr"></param>
        public static void ExcuteSql(string sqlstr, string dbname)
        {
            try
            {
                OpenConnection(dbname);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = sqlstr;
                Comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            { CloseConnection(); }
        }
        /**//// <summary>
        /// 返回指定sql语句的OleDbDataReader对象，使用时请注意关闭这个对象。
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static OleDbDataReader DataReader(string sqlstr, string dbname)
        {
            OleDbDataReader dr = null;
            try
            {
                OpenConnection(dbname);
                Comm.CommandText = sqlstr;
                Comm.CommandType = CommandType.Text;
                dr = Comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                try
                {
                    dr?.Close();
                    CloseConnection();
                }
                catch
                {
                    // ignored
                }
            }
            return dr;
        }
        /**//// <summary>
        /// 返回指定sql语句的OleDbDataReader对象,使用时请注意关闭
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="dr"></param>
        public static void DataReader(string sqlstr, ref OleDbDataReader dr, string dbname)
        {
            try
            {
                OpenConnection(dbname);
                Comm.CommandText = sqlstr;
                Comm.CommandType = CommandType.Text;
                dr = Comm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                try
                {
                    if (dr != null && !dr.IsClosed)
                        dr.Close();
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    CloseConnection();
                }
            }
        }
        /**//// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataSet DataSet(string sqlstr, string dbname)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection(dbname);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = sqlstr;
                da.SelectCommand = Comm;
                da.Fill(ds); 
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            { 
                CloseConnection();
            }
            return ds;
        }
        /**//// <summary>
        /// 返回指定sql语句的dataset
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="ds"></param>
        public static void DataSet(string sqlstr, ref DataSet ds, string dbname)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection(dbname);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = sqlstr;
                da.SelectCommand = Comm;
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        /**//// <summary>
        /// 返回指定sql语句的datatable
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataTable DataTable(string sqlstr, string dbname)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection(dbname);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = sqlstr;
                da.SelectCommand = Comm;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
        /**//// <summary>
        /// 返回指定sql语句的datatable
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <param name="dt"></param>
        public static void DataTable(string sqlstr, ref DataTable dt, string dbname)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection(dbname);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = sqlstr;
                da.SelectCommand = Comm;
                da.Fill(dt);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        /**//// <summary>
        /// 返回指定sql语句的dataview
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public static DataView DataView(string sqlstr, string dbname)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataView dv;
            DataSet ds = new DataSet();
            try
            {
                OpenConnection(dbname);
                Comm.CommandType = CommandType.Text;
                Comm.CommandText = sqlstr;
                da.SelectCommand = Comm;
                da.Fill(ds);
                dv = ds.Tables[0].DefaultView;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dv;
        }

    }
}