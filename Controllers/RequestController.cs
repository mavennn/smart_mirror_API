using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Repositories;
using SmartMirror.Domain.Enums;
using SmartMirror.Domain.Models;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RequestController : SmartMirrorBaseController
    {
        
        public RequestController(IUnitOfWork uow) : base(uow)
        {
        }


        [HttpPost]
        [Route("{consultantId}/{requestId}")]
        public IActionResult TakeInWork (string consultantId, string requestId)
        {

            if (string.IsNullOrEmpty(consultantId) || string.IsNullOrEmpty(requestId)) return Json(null);

            var request = _uow.RequestRepository.Items.Where(r => r.Id.ToString() == requestId).FirstOrDefault();

            _uow.RequestRepository.Delete(request);

            _uow.RequestRepository.Add(new Request
            {
                Id = request.Id,
                Title = request.Title,
                Type = request.Type,
                Time = request.Time,
                ConsulantId = new Guid(consultantId),
                Status = RequestStatus.IN_PROCCESS,
                Products = request.Products,
                UserId = request.UserId
            });

            _uow.Commit();

            return Json(true);
        }


        [HttpPost]
        [Route("{consultantId}/{requestId}")]
        public IActionResult ToComplete (string consultantId, string requestId)
        {

            if (string.IsNullOrEmpty(consultantId) || string.IsNullOrEmpty(requestId)) return Json(null);

            var request = _uow.RequestRepository.Items.Where(r => r.Id.ToString() == requestId).FirstOrDefault();

            _uow.RequestRepository.Delete(request);

            _uow.RequestRepository.Add(new Request
            {
                Id = request.Id,
                Title = request.Title,
                Type = request.Type,
                Time = request.Time,
                ConsulantId = new Guid(consultantId),
                Status = RequestStatus.CLOSE,
                Products = request.Products,
                UserId = request.UserId
            });

            _uow.Commit();

            return Json(true);
        }


        [HttpPost]    
        public IActionResult Create([FromBody] Request request)
        {

            if (string.IsNullOrEmpty(request.Title)) return Json(null);

            if (string.IsNullOrEmpty(request.UserId.ToString())) return Json(null);

            if (string.IsNullOrEmpty(request.Type.ToString())) return Json(null);

            request.Id = Guid.NewGuid();
            request.Time = DateTime.Now;
            request.Status = RequestStatus.OPEN;

            // если передан объект вещи, сохранить его в таблицу RequestProducts
            if (request.Type == RequestType.BRING_THING && request.Products[0] != null)
            {
                _uow.RequestProductRepository.Add(new RequestProduct
                {
                    RequestId = request.Id,
                    ProductId = request.Products[0].Id
                });
            }

            if (request.Type == RequestType.TAKE_TO_CHECKOUT && request.Products.Any())
            {
                foreach(var product in request.Products)
                {
                    _uow.RequestProductRepository.Add(new RequestProduct
                    {
                        RequestId = request.Id,
                        ProductId = product.Id
                    });
                }
            }

            _uow.RequestRepository.Add(request);

            _uow.Commit();

            return Json(request.Id);
        }


        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetAllByUser (string userId)
        {

            if (string.IsNullOrEmpty(userId)) return Json(null);

            var requests = _uow.RequestRepository.Items.Where(r => r.UserId.ToString() == userId).ToList();

            return Json(requests);
        }



        [HttpGet]
        public IActionResult GetAllOpened ()
        {

            // находим все заявки в статусе "Открыто"
            var requests = _uow.RequestRepository.Items.Where(r => r.Status == RequestStatus.OPEN).ToList();

            // Добавляем фотки
            foreach (var request in requests)
            {
                if (request.Type == RequestType.BRING_THING)
                {
                    var requestProductId = _uow.RequestProductRepository.Items.Where(r => r.Id == request.Id).Select(r => r.ProductId).FirstOrDefault();
                    request.Products.Add(_uow.ProductsRepository.Items.Where(p => p.Id == requestProductId).FirstOrDefault());
                    request.Products[0].Images = _uow.ImagesRepository.Items.Where(img => img.ProductId == request.Products[0].Id).ToList();
                }

                if (request.Type == RequestType.TAKE_TO_CHECKOUT)
                {
                    var requestProductsIds = _uow.RequestProductRepository.Items.Where(r => r.Id == request.Id).Select(r => r.ProductId).ToList();

                    foreach(var rpi in requestProductsIds)
                    {
                        var product = _uow.ProductsRepository.Items.Where(p => p.Id == rpi).FirstOrDefault();
                        product.Images = _uow.ImagesRepository.Items.Where(img => img.ProductId == product.Id).ToList();
                        request.Products.Add(product);
                    }
                }
            }

            return Json(requests);
        }
    }
}
