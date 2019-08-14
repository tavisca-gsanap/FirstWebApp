using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Welcome";
        }

        // GET api/values/5
        [HttpGet("{message}")]
        public ActionResult<string> Get(string message)
        {
            if (message.ToLower().Equals("hi"))
            {
                return "Hello";
            }
            else if (message.ToLower().Equals("hello"))
            {
                return "Hi";
            }
            else
            {
                return "Invalid Token";
            }
        }



        // POST api/values
        [HttpPost]
        public ActionResult<JsonResult> Post([FromBody] string value)
        {
            JObject jObject = JObject.Parse(value);
            var message = jObject.GetValue("message");
            return new JsonResult(message);
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}