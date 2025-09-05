using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsRegistration.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
    }
}