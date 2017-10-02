using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class CaselbController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from caselb order by px desc,id desc", this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "caselb";
            return result; 
        }

        // GET api/values/5
        public DataSet GetbyId(int id)
        {
            var result =  DataAccess.DataSet("select * from caselb where id =" + id, this.Url.Request.RequestUri.Segments[1]);
            result.Tables[0].TableName = "caselb";
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
