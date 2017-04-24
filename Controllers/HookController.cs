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
            return new
            {
                message = "No data on this api.",
                success = false
            };
        }

        [HttpPost]
        public object Post([FromBody]dynamic value)
        {
            if (value.result.action == "LOGIN")
            {
                var result = value.result;
                var userName = result.parameters.UserName;
                if (!string.IsNullOrEmpty(userName))
                {
                    return Speech("No way! Did you forget to type your User Name?");
                }
                else if (!"se".Equals(userName))
                {
                    return Speech("Your User Name is not correct.");
                }
                else
                {
                    return Speech("Heyyyy! Welcome ^^ I'm so glad you here!");
                }
            }
            return value;
        }
        private dynamic Speech(string text)
        {
            return new
            {
                messages = new[]{
                            new {
                                type = 0,
                                speech = text
                            }
                        }
            };
        }
    }
}
