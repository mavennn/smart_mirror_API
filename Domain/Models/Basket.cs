using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMirror.Domain.Models
{
    public class Basket : Entity
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
