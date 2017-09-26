using System.Data;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class SortController : ApiController
    {
        // GET api/values
        public DataSet Get(int pageSize = 0, int pageNumber = 0)
        {
            var sqlstr = "select * from sort  order by px desc, sort_id desc";
            if (pageSize > 0)
            {
                sqlstr = "select top " + pageSize + " * from sort order by px desc, sort_id desc";
                if (pageNumber > 1)
                {
                    sqlstr = "select top " + pageSize + " * from sort where sort_id not in (select top " +
                             pageSize * (pageNumber - 1) +
                             " sort_id from sort order by px desc,sort_id desc) order by px desc, sort_id desc";
                }
            }

            var result = DataAccess.DataSet(sqlstr);
            result.Tables[0].TableName = "sort";
            return result;
        }

        // GET api/values/5
        public DataSet GetbySort_id(int sort_id)
        {
            var result = DataAccess.DataSet("select * from sort where sort_id =" + sort_id);
            result.Tables[0].TableName = "sort";
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
