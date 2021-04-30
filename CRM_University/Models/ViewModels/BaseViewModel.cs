using CRM_University.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_University.Models.ViewModels
{
    public class BaseViewModel
    {
        public int StudentId { get; set; }
        [Display(Name ="Անուն")]
        public string StudentFirstName { get; set; }
        [Display(Name = "Ազգանուն")]

        public string StudentLastName { get; set; }
        [Display(Name = "Ծննդյան ամսաթիվ")]

        public DateTime StudentBirthDate { get; set; }
        [Display(Name = "Սեռ")]

        public string StudentGender { get; set; }
        [Display(Name = "Քաղաք")]

        public string City { get; set; }
        [Display(Name = "Հասցե")]

        public string Address { get; set; }
        [Display(Name = "Երկիր")]

        public string Country { get; set; }
        [Display(Name = "Ընդունվելու ամսաթիվը")]

        public DateTime YearOfAdmission { get; set; }
        [Display(Name = "Ավարտելու ամսաթիվը")]

        public DateTime CompletionYear { get; set; }
        [Display(Name = "ՄՈԳ")]

        public double MOG { get; set; }
        [Display(Name = "Ստուգարքի արդյունքը")]

        public AssessmentResult AssesmentResult { get; set; }
        [Display(Name = "Քննության արդյունքը")]

        public byte ExaminationResult { get; set; }
        [Display(Name = "Քննության օրը")]
        public DateTime ExaminationDay { get; set; }
        [Display(Name = "Ֆակուլտետի ուսման վարձը")]

        public decimal FacultyFee { get; set; }
        [Display(Name = "Ֆակուլտետ")]

        public string FacultyName { get; set; }
        [Display(Name = "Խումբ")]

        public string GroupName { get; set; }
        [Display(Name = "Առարկա")]

        public string SubjectName { get; set; }
        [Display(Name = "Բացակայություններ")]

        public int Absences { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Վճարում")]

        public bool Paid { get; set; }
        [Display(Name ="Կարգավիճակ")]
        public StudentStatus Status { get; set; }
    }
}
