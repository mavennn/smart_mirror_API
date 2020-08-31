using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Models;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        public TestController()
        {

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = new Size()
            {
                Name = "Эсочка"
            };
            
            return Json(data);
        }
    }
}
