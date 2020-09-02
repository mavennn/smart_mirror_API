using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Models;

namespace SmartMirror.Domain.Repositories
{
    public class RequestProductsRepository : RepositoryBase<RequestProduct>
    {
        public RequestProductsRepository(SmartMirrorDbContext context) : base(context)
        {
        }
    }
}
