using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartMirror.Domain.Models
{
    public class RequestProduct : Entity
    {
        public Guid Id { get; set; }
        public Guid RequestId { get; set; }
        public Guid ProductId { get; set; }
    }
}
