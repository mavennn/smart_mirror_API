using SmartMirror.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMirror.Domain.Repositories
{
    public class HistoryRepository : RepositoryBase<HistoryItem>
    {
        public HistoryRepository(SmartMirrorDbContext context) : base(context)
        {
        }
    }
}
