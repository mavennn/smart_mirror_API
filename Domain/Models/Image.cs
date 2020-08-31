using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SmartMirror.Domain.Models
{
    public class Image : Entity
    {
        public string Url { get; set; }
    }
}
