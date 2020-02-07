using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shoeshoe.Models;
using shoeshoe.Services;

namespace shoeshoe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassroomsController : BaseAPIController<Classroom>
    {
        public ClassroomsController(ClassroomsService ss) : base(ss)
        {
        }

        [HttpDelete("{id}")]
        public override ActionResult<String> Delete(int id)
        {
            return NotFound();

        }
    }
}
