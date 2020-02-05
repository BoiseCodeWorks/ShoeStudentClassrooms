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
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService _ss;
        private readonly ClassroomsService _cs;
        public StudentsController(StudentsService ss, ClassroomsService cs)
        {
            _ss = ss;
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            try
            {
                return Ok(_ss.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            try
            {
                return Ok(_ss.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/classrooms")]
        public ActionResult<IEnumerable<Classroom>> GetClassrooms(int id)
        {
            try
            {
                return Ok(_cs.GetByStudentId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Student> Create([FromBody] Student newData)
        {
            try
            {
                return Ok(_ss.Create(newData));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Student> Edit([FromBody] Student update, int id)
        {
            try
            {
                update.Id = id;
                return Ok(_ss.Edit(update));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<String> Delete(int id)
        {
            try
            {
                return Ok(_ss.Delete(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
