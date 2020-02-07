using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shoeshoe.Models;
using shoeshoe.Services;

namespace shoeshoe.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class StudentsController : BaseAPIController<Student>
    {
        public StudentsController(StudentsService ss) : base(ss)
        {
        }
    }
}
