using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using shoeshoe.Interfaces;

namespace shoeshoe.Controllers
{
    public class BaseAPIController<T> : ControllerBase
    {
        private readonly IService<T> _ss;
        public BaseAPIController(IService<T> ss)
        {
            _ss = ss;
        }

        [HttpGet]
        public virtual ActionResult<IEnumerable<T>> Get()
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
        public virtual ActionResult<T> Get(int id)
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

        [HttpPost]
        public virtual ActionResult<T> Create([FromBody] T newData)
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
        public virtual ActionResult<T> Edit([FromBody] T update, int id)
        {
            try
            {
                return Ok(_ss.Edit(update, id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public virtual ActionResult<String> Delete(int id)
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
