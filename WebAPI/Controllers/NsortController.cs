using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class NsortController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from nsort", this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "nsort";
            return result; 
        }

        // GET api/values/5
        public DataSet GetbyNsort_id(int nsort_id)
        {
            var result =  DataAccess.DataSet("select * from nsort where nsort_id =" + nsort_id, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "nsort";
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
