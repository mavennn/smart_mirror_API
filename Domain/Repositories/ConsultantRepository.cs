using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Models;

namespace SmartMirror.Domain.Repositories
{
    public class ConsultantRepository : RepositoryBase<Consultant>
    {
        public ConsultantRepository(SmartMirrorDbContext context) : base(context)
        {

        }
    }
}
