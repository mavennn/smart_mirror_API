using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMirror.Domain.Repositories;

namespace SmartMirror.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RequestController : SmartMirrorBaseController
    {
        
        public RequestController(IUnitOfWork uow) : base(uow)
        {

        }
    }
}
