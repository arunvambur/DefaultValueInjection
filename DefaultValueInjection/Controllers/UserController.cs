using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DefaultValueInjection.Filters;
using DefaultValueInjection.Model;

namespace DefaultValueInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [ServiceFilter(typeof(DefaultUserPreferenceSettingsFilter))]
        [HttpPost]
        public ActionResult AddUser([FromBody]UserProfile userProfile)
        {

            return Ok(userProfile);
        }
    }
}
