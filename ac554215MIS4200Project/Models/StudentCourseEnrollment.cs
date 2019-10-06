using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ac554215MIS4200Project.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class student
    {
        [Display(Name = "Student ID")]
        [Required(ErrorMessage = "Student ID is required")]
        public int studentID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(20)]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20)]
        public string lastName { get; set; }
        [Display(Name = "When was the student initially enrolled?")]
        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.DateTime)]
        public DateTime studentSince { get; set; }
        [Display(Name = "What is the student's weight?")]
        [Required(ErrorMessage = "Student weight is required")]
        public decimal weight { get; set; }
        public ICollection<enrollment> enrollment { get; set; }
        [Display(Name = "Full Name")]
        public string fullName { get { return lastName + ", " + firstName; } }
    }
    public class course
    {
        [Display (Name = "Course ID")]
        [Required (ErrorMessage = "Course ID is required")]
        public int courseID { get; set; }
        [Display (Name = "Course Title")]
        [Required(ErrorMessage = "Course title is required")]
        [StringLength(20)]
        public string title { get; set; }
        [Display (Name = "Course Description")]
        [Required(ErrorMessage = "Course description is required")]
        [StringLength(100)]
        public string description { get; set; }
        public ICollection<enrollment> enrollment { get; set; }
    }
    public class enrollment
    {
        [Display (Name = "Enrollment ID")]
        [Required(ErrorMessage = "Enrollment ID is required")]
        public int enrollmentID { get; set; }
        [Display (Name = "Student ID")]
        [Required(ErrorMessage = "Student ID is required")]
        public int studentID { get; set; }
        public virtual student student { get; set; }
        [Display (Name = "Course ID")]
        [Required(ErrorMessage = "Course ID is required")]
        public int courseID { get; set; }
        public virtual course course { get; set; }
    }
}