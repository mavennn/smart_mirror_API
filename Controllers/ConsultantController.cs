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
    public class ConsultantController : SmartMirrorBaseController
    {
        public ConsultantController(IUnitOfWork uow) : base(uow)
        {
        }

      
        [HttpPost]
        [Route("{name}")]
        public IActionResult Login(string name)
        {
            if (string.IsNullOrEmpty(name)) return Json(null);

            var newConsulantId = Guid.NewGuid();

            var newConsulant = new Consultant
            {
                Id = newConsulantId,
                Name = name,
                Status = ConsultantStatus.FREE
            };

            // проверяем есть ли такой пользователь в системе
            var existingConsultant = _uow.ConsultantsRepository.Items.Where(c => c.Name== name).FirstOrDefault();

            // если нет, то создаем его
            if (existingConsultant == null)
            {
                _uow.ConsultantsRepository.Add(newConsulant);
            } else
            {
                // если есть, то оставялем его ID
                newConsulantId = existingConsultant.Id;
            }
                
            _uow.Commit();

            return Json(newConsulantId);
        }
    }
}
