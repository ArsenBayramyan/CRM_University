using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }
        public int FacultyId { get; set; }
        public string GroupName { get; set; }

    }
}
