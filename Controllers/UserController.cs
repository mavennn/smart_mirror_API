using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Models;
using SmartMirror.Domain.Repositories;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : SmartMirrorBaseController
    {
        public UserController(IUnitOfWork uow) : base(uow)
        {
        }

   
        [HttpPost]
        public IActionResult Login ([FromBody] User user)
        {

            if (string.IsNullOrEmpty(user.UserAgent)) return Json(null);

            var newUserId = Guid.NewGuid();

            var newUser = new User
            {
                Id = newUserId,
                UserAgent = user.UserAgent
            };

            // проверяем есть ли такой пользователь в системе
            var existingUser = _uow.UsersRepository.Items.Where(u => u.UserAgent == user.UserAgent).FirstOrDefault();

            // если нет, то создаем его
            if (existingUser == null)
            {
                _uow.UsersRepository.Add(newUser);
            } else
            {
                // если есть, то оставялем его ID
                newUserId = existingUser.Id;
            }
                
            _uow.Commit();

            return Json(newUserId);
        }

        [HttpPost]
        [Route("{userId}")]
        public IActionResult Reset (string userId)
        {

            if (string.IsNullOrEmpty(userId)) return Json(null);

            var user = _uow.UsersRepository.Items.Where(u => u.Id.ToString() == userId).FirstOrDefault();

            if (user == null) return Json(null);

            // удаляем всю историю просмотров
            var historyItems = _uow.HistoryRepository.Items.Where(hi => hi.UserId.ToString() == userId).ToList();

            foreach (var item in historyItems)
            {
                _uow.HistoryRepository.Delete(item);
            }

            // чистим всю его корзину
            var basketItems = _uow.BasketRepository.Items.Where(bi => bi.UserId.ToString() == userId).ToList();
            
            foreach(var item in basketItems)
            {
                _uow.BasketRepository.Delete(item);
            }

            _uow.Commit();

            return Json(true);
        }


    }
}
