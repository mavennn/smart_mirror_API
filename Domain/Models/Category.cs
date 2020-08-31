using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartMirror.Domain.Models
{
    public class Category : Entity
    {

        public Category()
        {

        }

        public string Name { get; set; }
        public string Sex { get; set; }
    }
}
