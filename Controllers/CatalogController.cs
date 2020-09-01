using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Repositories;
using SmartMirror.Domain.Models;
using SmartMirror.Domain.Enums;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CatalogController : SmartMirrorBaseController
    {
        public CatalogController(IUnitOfWork uow) : base(uow)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        [HttpGet("{gender}")]
        public IActionResult GetProductsByGender(GenderTypes gender)
        {
            var products = _uow.ProductsRepository
                                        .Items
                                        .Where(p => p.Gender == gender)
                                        .ToList();

            foreach(var product in products)
            {
                product.Sizes = _uow.SizeRepository.Items
                                        .Where(s => s.ProductId == product.Id)
                                        .Select(s => new Size
                                        {
                                            Name = s.Name,
                                            ProductId = s.ProductId,
                                            Id = s.Id,
                                            EU = s.EU
                                        }).ToList();

                product.Images = _uow.ImagesRepository.Items.Where(img => img.ProductId == product.Id).Select(img => new Image
                {
                    Id = img.Id,
                    Url = img.Url,
                    ProductId = img.ProductId
                }).ToList();

                product.Category = _uow.CategoriesRepository.Items.Where(c => c.ProductId == product.Id).Select(c => new Category
                {
                    Name = c.Name,
                    Id = c.Id,
                    ProductId = c.ProductId
                }).FirstOrDefault();
            }


            return Json(products);
        }

    }
}
