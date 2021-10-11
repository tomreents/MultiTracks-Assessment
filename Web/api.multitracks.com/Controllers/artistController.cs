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
    // controller for two api action for the Artist table add() and search()
    public class artistController : ApiController
    {
        database_access_layer.db dblyer = new database_access_layer.db();
        artist cs = new artist();
        [HttpPost]
        // POST api/values
        public IHttpActionResult add([FromBody]artist cs)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                dblyer.add(cs);
                return Ok("Success");
            }
            catch (Exception)
            {
                return Ok("Something wnt wrong");
            }
        }
        [HttpGet]
        public DataSet search(string title)
        {
            DataSet ds = dblyer.search(title);
            return ds;
        }
    }
}