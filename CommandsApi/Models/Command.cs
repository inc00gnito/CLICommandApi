﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsApi.Models
{
    public class Command
    {
        public int Id { get; set; }
        [Required]
        public string CommandName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
