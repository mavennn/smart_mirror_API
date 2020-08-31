using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Models;

namespace SmartMirror.Domain.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        public CategoryRepository(SmartMirrorDbContext context) : base(context)
        {

        }
    }
}
