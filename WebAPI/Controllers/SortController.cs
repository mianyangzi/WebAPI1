﻿using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class SortController : ApiController
    {
        // GET api/values
        public DataSet Get()
        {
            var result = DataAccess.DataSet("select * from sort");
            result.Tables[0].TableName = "sort";
            return result; 
        }

        // GET api/values/5
        public DataSet Get(int id)
        {
            var result =  DataAccess.DataSet("select * from sort where id =" + id);
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
