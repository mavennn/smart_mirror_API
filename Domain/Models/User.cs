
using System.Collections.Generic;

namespace SmartMirror.Domain.Models
{
    public class User : Entity
    {

        public User()
        {
            BasketItems = new List<Product>(); 
            HistoryItems = new List<Product>(); 
        } 

        public string UserAgent { get; set; }
        public List<Product> BasketItems { get; set; }
        public List<Product> HistoryItems { get; set; }
    }
}
