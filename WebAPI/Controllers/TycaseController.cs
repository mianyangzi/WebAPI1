using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class TycaseController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from tycase");
            result.Tables[0].TableName = "tycase";
            return result; 
        }

        // GET api/values/5
        public DataSet Get(int id)
        {
            var result =  DataAccess.DataSet("select * from tycase where id =" + id);
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
