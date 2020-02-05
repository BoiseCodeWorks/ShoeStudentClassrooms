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
    public class ClassroomStudentsController : ControllerBase
    {
        private readonly ClassroomStudentsService _ss;
        public ClassroomStudentsController(ClassroomStudentsService ss)
        {
            _ss = ss;
        }

        [HttpPost]
        public ActionResult<String> Create([FromBody] ClassroomStudent newData)
        {
            try
            {
                _ss.Create(newData);
                return Ok("Success");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("/removeStudent")]
        public ActionResult<String> Edit([FromBody] ClassroomStudent cs)
        {
            try
            {
                return Ok(_ss.Delete(cs));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}




