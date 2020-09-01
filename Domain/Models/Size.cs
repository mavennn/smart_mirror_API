using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartMirror.Domain.Models
{

    public class Size : Entity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EU { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }
    }
}
