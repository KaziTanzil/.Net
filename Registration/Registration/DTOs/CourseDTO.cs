using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.DTOs
{
    public class CourseDTO
    {
        public int CId { get; set; }
        public string CName { get; set; }
        public string Credit { get; set; }
        public string TCapacity { get; set; }
        public string Count { get; set; }
    }
}