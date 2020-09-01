using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SmartMirror.Domain.Models;
using SmartMirror.Domain.Repositories;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BasketController : SmartMirrorBaseController
    {
        public BasketController(IUnitOfWork uow) : base(uow)
        {

        }


        [HttpPost]
        [Route("{userId}/{productId}")]
        public IActionResult Add (string userId, string productId)
        {

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(productId)) return Json(null);

            var user = _uow.UsersRepository.Items.Where(u => u.Id == new Guid(userId)).FirstOrDefault();

            var product = _uow.ProductsRepository.Items.Where(p => p.Id == new Guid(productId)).FirstOrDefault();

            var newBasketItem = new Basket
            {
                User = user,
                UserId = user.Id,
                Product = product,
                ProductId = product.Id
            };

            // провереям есть ли уже такой предмет в корзине
            var existingItem = _uow.BasketRepository.Items.Where(b => b.UserId.ToString() == userId && b.ProductId.ToString() == productId).FirstOrDefault();


            // если такой предмет уже есть в корзине
            if (existingItem != null)
            {
                return Json("Уже есть в корзине");
            }

            _uow.BasketRepository.Add(newBasketItem);

            _uow.Commit();

            var result = _uow.BasketRepository.Items.Where(b => b.UserId.ToString() == userId && b.ProductId.ToString() == productId).FirstOrDefault();

            return Json(result);
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAll (string userId)
        {
            if (string.IsNullOrEmpty(userId)) return Json(null);

            var user = _uow.UsersRepository.Items.Where(u => u.Id == new Guid(userId)).FirstOrDefault();

            var userBasketItems = _uow.BasketRepository.Items.Where(bi => bi.UserId == user.Id).ToList();

            var result = new List<Product>();

            // по всем вещам в корзине создаем объекты Product
            foreach (var basketItem in userBasketItems)
            {
                var product = _uow.ProductsRepository.Items.Where(p => p.Id == basketItem.ProductId).FirstOrDefault();

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

                result.Add(product);
            }

            return Json(result);
        }


        [HttpPost]
        [Route("{userId}/{productId}")]
        public IActionResult RemoveItem(string userId, string productId)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(productId)) return Json(null);

            var basketItem = _uow.BasketRepository.Items.Where(b => b.UserId.ToString() == userId && b.ProductId.ToString() == productId).FirstOrDefault();

            if (basketItem != null)
            {
                _uow.BasketRepository.Delete(basketItem);

                _uow.Commit();
            }

            var freshBasketItems = _uow.BasketRepository.Items.Where(b => b.UserId.ToString() == userId).ToList();

            var result = new List<Product>();

            foreach (var bi in freshBasketItems)
            {
                var product = _uow.ProductsRepository.Items.Where(p => p.Id == bi.ProductId).FirstOrDefault();

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

                result.Add(product);
            }

            return Json(result);
        }


        [HttpPost]
        [Route("{userId}")]
        public IActionResult Clear (string userId)
        {
            if (string.IsNullOrEmpty(userId)) return Json(null);

            var userBasketItems = _uow.BasketRepository.Items.Where(bi => bi.UserId.ToString() == userId).ToList();

            foreach (var basketItem in userBasketItems)
            {
                _uow.BasketRepository.Delete(basketItem);
            }

            _uow.Commit();
            
            return Ok();
        }

    }
}
