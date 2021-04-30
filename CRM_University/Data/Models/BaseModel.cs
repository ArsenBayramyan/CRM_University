using CRM_University.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Data.Models
{
    public class BaseModel
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public DateTime StudentBirthDate { get; set; }
        public string StudentGender { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public DateTime YearOfAdmission { get; set; }
        public DateTime CompletionYear { get; set; }
        public double MOG { get; set; }
        public AssessmentResult AssesmentResult { get; set; }
        public byte ExaminationResult { get; set; }
        public DateTime ExaminationDay { get; set; }
        public decimal FacultyFee { get; set; }
        public string FacultyName { get; set; }
        public string GroupName { get; set; }
        public string SubjectName { get; set; }
        public int Absences { get; set; }
        public string Email { get; set; }
        public bool Paid { get; set; }
        public StudentStatus Status { get; set; }

    }
}
