using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class GsxmnrController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from gsxmnr");
            result.Tables[0].TableName = "gsxmnr";
            return result; 
        }

        // GET api/values/5
        public DataSet Get(int id)
        {
            var result =  DataAccess.DataSet("select * from gsxmnr where id =" + id);
            result.Tables[0].TableName = "gsxmnr";
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
