﻿using System.Data;
using System.Web.Http; 

namespace WebAPI.Controllers
{
    public class CpController : ApiController
    {
        // GET api/values
        public DataTable Get()
        {
            var result = DataAccess.DataTable("select * from cp");
            return result; 
        }

        // GET api/values/5
        public DataTable Get(int id)
        {
            var result =  DataAccess.DataTable("select * from cp where id ="+id);
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
