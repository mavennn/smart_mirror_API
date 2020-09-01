using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMirror.Domain.Models
{
    public class CreateMany : Entity
    {
        public List<Product> products { get; set; }
    }
}
