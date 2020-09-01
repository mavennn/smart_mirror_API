using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Repositories;
using SmartMirror.Domain.Models;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HistoryController : SmartMirrorBaseController
    {
        public HistoryController(IUnitOfWork uow) : base(uow)
        {
        }

        [HttpPost]
        [Route("{userId}/{productId}")]
        public IActionResult Write (string userId, string productId)
        {

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(productId)) return Json(null);

            var user = _uow.UsersRepository.Items.Where(u => u.Id.ToString() == userId).FirstOrDefault();
            var product = _uow.ProductsRepository.Items.Where(p => p.Id.ToString() == productId).FirstOrDefault();

            if (user == null || product == null) return Json(null);

            // если продукт уже есть в истории просмотров, то повторно его не добавляем
            var existingItem = _uow.HistoryRepository.Items.Where(hi => hi.UserId.ToString() == userId && hi.ProductId.ToString() == productId).FirstOrDefault();

            if (existingItem != null) return Json(null);

            var newHistoryItem = new HistoryItem
            {
                UserId = user.Id,
                ProductId = product.Id
            };

            _uow.HistoryRepository.Add(newHistoryItem);

            _uow.Commit();

            return Json(true);
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAll (string userId)
        {
            if (string.IsNullOrEmpty(userId)) return Json(null);

            var result = new List<Product>();

            var historyItemsIds = _uow.HistoryRepository.Items.Where(hi => hi.UserId.ToString() == userId).Select(hi => hi.ProductId);

            foreach (var historyItemId in historyItemsIds)
            {
                var historyProduct = _uow.ProductsRepository.Items.Where(p => p.Id == historyItemId).FirstOrDefault();

                historyProduct.Sizes = _uow.SizeRepository.Items
                                        .Where(s => s.ProductId == historyItemId)
                                        .Select(s => new Size
                                        {
                                            Name = s.Name,
                                            ProductId = s.ProductId,
                                            Id = s.Id,
                                            EU = s.EU
                                        }).ToList();

                historyProduct.Images = _uow.ImagesRepository.Items.Where(img => img.ProductId == historyItemId).Select(img => new Image
                {
                    Id = img.Id,
                    Url = img.Url,
                    ProductId = img.ProductId
                }).ToList();

                historyProduct.Category = _uow.CategoriesRepository.Items.Where(c => c.ProductId == historyItemId).Select(c => new Category
                {
                    Name = c.Name,
                    Id = c.Id,
                    ProductId = c.ProductId
                }).FirstOrDefault();

                result.Add(historyProduct);
            };



            return Json(result);
        }

    }
}
