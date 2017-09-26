using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class CptpController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from cptp");
            result.Tables[0].TableName = "ppt";
            return result; 
        }

        // GET api/values/5
        public DataSet GetbyId(int id)
        {
            var result =  DataAccess.DataSet("select * from cptp where id =" + id);
            result.Tables[0].TableName = "ppt";
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
