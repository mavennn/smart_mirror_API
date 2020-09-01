using SmartMirror.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMirror.Domain.Models
{
    public class Category : Entity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ProductId { get; set; }
    }
}
