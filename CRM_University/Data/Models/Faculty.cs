﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyId { get; set; }
        public decimal Fee { get; set; }
        public string FacultyName { get; set; }
    }
}
