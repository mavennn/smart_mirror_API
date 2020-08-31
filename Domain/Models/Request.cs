using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Enums;

namespace SmartMirror.Domain.Models
{

    public class Request : Entity
    {

        public RequestType Type { get; set; }

        public User User { get; set; }

        public Consultant Consultant { get; set; }

    }
}
