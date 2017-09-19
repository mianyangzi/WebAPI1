using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class XwlbController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from xwlb");
            result.Tables[0].TableName = "xwlb";
            return result; 
        }

        // GET api/values/5
        public DataSet Get(int id)
        {
            var result =  DataAccess.DataSet("select * from xwlb where id =" + id);
            result.Tables[0].TableName = "xwlb";
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
