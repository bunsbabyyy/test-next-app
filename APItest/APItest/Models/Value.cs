﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Simple.Models
{
    public class Value
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}