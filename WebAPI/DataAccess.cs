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
        private static void OpenConnection()
        {
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.ConnectionString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConfigurationManager.AppSettings["myconn"];//web.config文件里设定。            
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
        public static void ExcuteSql(string sqlstr)
        {
            try
            {
                OpenConnection();
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
        public static OleDbDataReader DataReader(string sqlstr)
        {
            OleDbDataReader dr = null;
            try
            {
                OpenConnection();
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
        public static void DataReader(string sqlstr, ref OleDbDataReader dr)
        {
            try
            {
                OpenConnection();
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
        public static DataSet DataSet(string sqlstr)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
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
        public static void DataSet(string sqlstr, ref DataSet ds)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
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
        public static DataTable DataTable(string sqlstr)
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
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
        public static void DataTable(string sqlstr, ref DataTable dt)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                OpenConnection();
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
        public static DataView DataView(string sqlstr)
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataView dv;
            DataSet ds = new DataSet();
            try
            {
                OpenConnection();
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