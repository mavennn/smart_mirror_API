using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartMirror.Domain.Models
{
    public class Size : Entity
    {
        public string Name { get; set; }
        public string EU { get; set; }
    }
}
