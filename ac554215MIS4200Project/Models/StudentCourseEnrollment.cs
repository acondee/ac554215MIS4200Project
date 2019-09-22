using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ac554215MIS4200Project.Models
{
    public class student
    {
        public int studentID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime studentSince { get; set; }
        public decimal weight { get; set; }
        public ICollection<enrollment> enrollment { get; set; }
        public string fullName { get { return lastName + ", " + firstName; } }
    }
    public class course
    {
        public int courseID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public ICollection<enrollment> enrollment { get; set; }
    }
    public class enrollment
    {
        public int enrollmentID { get; set; }
        public int studentID { get; set; }
        public virtual student student { get; set; }
        public int courseID { get; set; }
        public virtual course course { get; set; }
    }
}