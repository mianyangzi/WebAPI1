using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class XwController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from xw order by shijian desc,id desc", this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "xw";
            return result; 
        }


        // GET api/values
        public DataSet GetbyXwlb_id(int xwlb_id)
        {
            var sqlstr = "select * from xw where xwlb_id = " + xwlb_id + " order by shijian desc,id desc";
            var result = DataAccess.DataSet(sqlstr, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "xw";
            return result;
        }



        // GET api/values/5
        public DataSet GetbyId(int id)
        {
            var result =  DataAccess.DataSet("select * from xw where id =" + id, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "xw";
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
