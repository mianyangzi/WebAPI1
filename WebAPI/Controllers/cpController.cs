using System;
using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class CpController : ApiController
    {

        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from cp order by px desc,id desc", this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "cp";
            return result;
        }



        // GET api/values
        public DataSet Getbys4(string s4="")
        {
            var sqlstr = "select * from cp order by px desc,id desc";
            if (!string.IsNullOrEmpty(s4))
            {
                sqlstr = "select * from cp where s4 = '" + s4 + "' order by px desc,id desc";
            }
            var result = DataAccess.DataSet(sqlstr, this.Url.Request.RequestUri.Segments[1]);
            
            result.Tables[0].TableName = "cp";

            return result; 
        }


        // GET api/values
        public DataSet Getbys1(string s1 = "")
        {
            var sqlstr = "select cp.*,sort.sort_name from cp left join sort  on cp.sort_id = sort.sort_id order by cp.px desc,cp.id desc";
            if (!string.IsNullOrEmpty(s1))
            {
                sqlstr = "select cp.*,sort.sort_name from cp left join sort  on cp.sort_id = sort.sort_id  where cp.s1  like '%" + s1 + "%' order by cp.px desc,cp.id desc";
            }
            var result = DataAccess.DataSet(sqlstr, this.Url.Request.RequestUri.Segments[1]);

            result.Tables[0].TableName = "cp";

            return result;
        }



        // GET api/values
        public DataSet Getbysort_id(string sort_id = "")
        {
            var sqlstr = "select * from cp order by px desc,id desc";
            if (!string.IsNullOrEmpty(sort_id))
            {
                sqlstr = "select * from cp where  sort_id like '%%," + sort_id + ",%%' order by px desc,id desc";
            }
            var result = DataAccess.DataSet(sqlstr, this.Url.Request.RequestUri.Segments[1]);

            result.Tables[0].TableName = "cp";

            return result;
        }



        // GET api/values
        public DataSet Getbynsort_id(int nsort_id)
        {
            var sqlstr = "select * from cp where nsort_id = " + nsort_id + " order by px desc,id desc";
            var result = DataAccess.DataSet(sqlstr, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "cp";
            return result;
        }



        // GET api/values/5
        public DataSet GetbyId(int id)
        {
            var result =  DataAccess.DataSet("select * from cp where id ="+id, this.Url.Request.RequestUri.Segments[1]);
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
