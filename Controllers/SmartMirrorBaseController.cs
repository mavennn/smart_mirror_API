using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Repositories;

namespace SmartMirror.Controllers
{
    public class SmartMirrorBaseController : Controller
    {
        protected readonly IUnitOfWork _uow;

        public SmartMirrorBaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }
    }
}
