using System;
using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class CpController : ApiController
    {
        // GET api/values
        public DataSet getbys4(string s4="")
        {
            var sqlstr = "select * from cp order by px desc,id desc";
            if (!string.IsNullOrEmpty(s4))
            {
                sqlstr = "select * from cp where s4 = '" + s4 + "' order by px desc,id desc";
            }
            var result = DataAccess.DataSet(sqlstr);
            
            result.Tables[0].TableName = "cp";

            return result; 
        }


        // GET api/values
        public DataSet getbys1(string s1 = "")
        {
            var sqlstr = "select * from cp order by px desc,id desc";
            if (!string.IsNullOrEmpty(s1))
            {
                sqlstr = "select * from cp where s1  like '%" + s1 + "%' order by px desc,id desc";
            }
            var result = DataAccess.DataSet(sqlstr);

            result.Tables[0].TableName = "cp";

            return result;
        }



        // GET api/values
        public DataSet getbysort_id(int sort_id)
        {
            var sqlstr = "select * from cp where sort_id = " + sort_id + " order by px desc,id desc";
            var result = DataAccess.DataSet(sqlstr);
            result.Tables[0].TableName = "cp";
            return result;
        }

        // GET api/values
        public DataSet getbynsort_id(int nsort_id)
        {
            var sqlstr = "select * from cp where nsort_id = " + nsort_id + " order by px desc,id desc";
            var result = DataAccess.DataSet(sqlstr);
            result.Tables[0].TableName = "cp";
            return result;
        }



        // GET api/values/5
        public DataSet GetbyId(int id)
        {
            var result =  DataAccess.DataSet("select * from cp where id ="+id);
            result.Tables[0].TableName = "cp";
            return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        } 
         
    }
}
