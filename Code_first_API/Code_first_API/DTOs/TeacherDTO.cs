using Code_first_API.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_first_API.DTOs
{
    public class TeacherDTO
    {

        public int TeacherId { get; set; }
        public string Name { get; set; }

        public int DeptId { get; set; }


    }
}