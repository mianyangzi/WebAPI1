using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class TyhonorController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            DataSet result = DataAccess.DataSet("select * from tyhonor order by px desc,id desc");
            result.Tables[0].TableName = "tyhonor";
            return result; 
        }

        // GET api/values/5
        public DataSet Get(int id)
        {
            var result =  DataAccess.DataSet("select * from tyhonor where id =" + id);
            result.Tables[0].TableName = "tyhonor";
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
