using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class CcController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from cc", this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "cc";
            return result; 
        }

        // GET api/values/5
        public DataSet GetbyId(int id)
        {
            var result =  DataAccess.DataSet("select * from cc where id =" + id, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "cc";
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
