using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Enums;

namespace SmartMirror.Domain.Models
{

    public class Consultant : Entity
    {
        public string Name { get; set; }

        public ConsultantStatus Status { get; set; }
    }
}
