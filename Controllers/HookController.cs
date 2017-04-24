using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace api_test.Controllers
{
    [Route("[controller]")]
    public class HookController : Controller
    {
        [HttpGet]
        public object Get()
        {
            return new {
                message = "No data on this api.",
                success = false
            };
        }

        [HttpPost]
        public object Post([FromBody]string value)
        {

            return default(object);
        }
    }
}
