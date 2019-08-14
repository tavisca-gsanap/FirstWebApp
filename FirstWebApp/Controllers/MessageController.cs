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
    }
}
