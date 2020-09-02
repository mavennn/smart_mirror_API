using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMirror.Domain.Models;
using SmartMirror.Domain.Enums;

namespace SmartMirror.Dtos
{
    public class RequestDto
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
