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

            System.Diagnostics.Debug.WriteLine("sdfsdfdf");
            var products = _uow.ProductsRepository.Items;

            foreach (var product in products)
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


        [HttpGet("{barcode}")]
        public IActionResult GetByBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode)) return Json(null);

            // находим вещь в бд
            var product = _uow.ProductsRepository.Items.Where(p => p.Barcode == barcode).FirstOrDefault();

            if (product == null) return Json(null);
            
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

            return Json(product);
        }


        [HttpPost]
        public IActionResult CreateMany([FromBody] List<Product> products)
        {

            if (products == null) return Json(null);
            
            foreach (var product in products)
            {
                var newProductId = Guid.NewGuid();

                var p = new Product()
                {
                    Id = newProductId,
                    Name = product.Name,
                    Price = product.Price,
                    VendorCode = product.VendorCode,
                    Brand = product.Brand,
                    Sizes = product.Sizes.Select(s => new Size
                    {
                        Id = Guid.NewGuid(),
                        ProductId = newProductId,
                        Name = s.Name
                    }).ToList(),
                    Barcode = product.Barcode,
                    Gender = product.Gender,
                    Category = new Category { 
                        Name = product.Category.Name, 
                        ProductId = newProductId, 
                        Id = Guid.NewGuid() 
                    },
                    Images = product.Images.Select(img => new Image
                    {
                        Id = Guid.NewGuid(),
                        Url = img.Url,
                        ProductId = product.Id
                    }).ToList()
                };

                _uow.ProductsRepository.Add(p);
            }
            

            _uow.Commit();
            

            return Json(true);
        }

    }
}
