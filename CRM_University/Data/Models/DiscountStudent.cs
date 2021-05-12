using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class DiscountStudent
    {
        public int DiscountStudentId { get; set; }
        public int StudentId { get; set; }
        public DateTime DiscountDate { get; set; }
        public string DiscountName { get; set; }
    }
}
