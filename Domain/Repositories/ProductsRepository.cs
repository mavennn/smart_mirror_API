using SmartMirror.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Models;

namespace SmartMirror.Domain
{
    public class ProductsRepository : RepositoryBase<Product>
    {
        public ProductsRepository(SmartMirrorDbContext context) : base(context)
        {
        }
    }
}
