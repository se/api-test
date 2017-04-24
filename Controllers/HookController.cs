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
            var isCompleted = false;

            if (value != null && value.result != null && value.result.actionIncomplete == false)
            {
                isCompleted = true;
            }

            if (!isCompleted)
            {
                return null;
            }

            if (value.result.action == "LOGIN")
            {
                var result = value.result;
                var userName = (string)value.result.parameters.UserName;
                var password = (string)value.result.parameters.Password;
                if (string.IsNullOrEmpty(userName))
                {
                    return Speech("No way! Did you forget to type your User Name?");
                }
                else if (string.IsNullOrEmpty(password))
                {
                    return Speech("No way! Did you forget to type your Password? Come on man!");
                }
                else if (!"se".Equals(userName) || !"pass".Equals(password))
                {
                    return Speech("Your User Name or Password is not correct.");
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
