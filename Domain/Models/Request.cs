using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Enums;

namespace SmartMirror.Domain.Models
{
    public class Request : Entity
    {
        public Guid Id { get; set; }
        public RequestType Type { get; set; }
        public RequestStatus Status { get; set; }
        public DateTime? Time { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public Guid ConsulantId { get; set; }
        public List<Product> Products { get; set; }
    }
}
