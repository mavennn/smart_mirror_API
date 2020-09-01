﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMirror.Domain.Models
{
    public class User : Entity
    {
        public Guid Id { get; set; }
        public string UserAgent { get; set; }
    }
}
