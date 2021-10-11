using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using api.multitracks.com.Models;

namespace api.multitracks.com.Controllers
{
    // controller for an api action on the Song db table  
    public class songController : ApiController
    {
        database_access_layer.db dblyer = new database_access_layer.db();

        [HttpGet]
        public IHttpActionResult list(int pageSize, int pageNumber)
        {
            var ds = dblyer.list(pageSize, pageNumber);
            return Ok(ds);
        }
    }
}
