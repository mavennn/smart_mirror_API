using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SmartMirror.Domain.Enums;

namespace SmartMirror.Domain.Models
{
    
    public class Product : Entity
    {

        public Product()
        {
            Sizes = new List<Size>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string VendorCode { get; set; }

        public string Brand { get; set; }

        public List<Size> Sizes { get; set; }

        public string Barcode { get; set; }

        public GenderTypes Gender { get; set; }
        public Category Category { get; set; }
        public List<Image> Images { get; set; }

    }
}
