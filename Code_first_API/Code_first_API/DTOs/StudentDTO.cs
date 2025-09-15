using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Code_first_API.DTOs
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

     
     
        public string Name { get; set; }



        public float? Cgpa { get; set; }



        public int DeptId { get; set; }
    }
}