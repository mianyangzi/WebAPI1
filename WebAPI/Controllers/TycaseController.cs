using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class TycaseController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from tycase order by px desc,id desc", this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "tycase";
            return result; 
        }


        // GET api/values
        public DataSet GetbyLb_id(int lb_id)
        {
            var sqlstr = "select * from tycase where lb_id = " + lb_id + " order by px desc,id desc";
            var result = DataAccess.DataSet(sqlstr, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "tycase";
            return result;
        }

        // GET api/values/5
        public DataSet GetbyId(int id)
        {
            var result =  DataAccess.DataSet("select * from tycase where id =" + id, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "tycase";
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
