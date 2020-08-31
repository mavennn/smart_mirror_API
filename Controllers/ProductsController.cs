using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Models;
using SmartMirror.Domain.Repositories;
using SmartMirror.Domain.Enums;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductsController : SmartMirrorBaseController
    {

        public ProductsController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var data = _uow.ProductsRepository.Items;

            return Json(data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var p = new Product()
            {
                Name = "Кроссовки ZENDEN active",
                Price = 29999,
                VendorCode = "189-01MV-002TT",
                Brand = "Zenden",
                Sizes = new List<Size>()
                {
                    new Size() { Name = "40", EU = "40" },
                    new Size() { Name = "41", EU = "41" },
                    new Size() { Name = "42", EU = "42" },
                    new Size() { Name = "43", EU = "43" },
                    new Size() { Name = "44", EU = "44" },
                    new Size() { Name = "45", EU = "45" },
                },
                Barcode = "2345678754567",
                Gender = GenderTypes.MALE


            };

            return Json(p);
        }

    }
}
