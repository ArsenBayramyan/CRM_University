﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class NotReceived
    {
        public int NotReceivedId { get; set; }
        public int FacultyId { get; set; }
        public int GroupId { get; set; }
        public int StudentId { get; set; }
    }
}
