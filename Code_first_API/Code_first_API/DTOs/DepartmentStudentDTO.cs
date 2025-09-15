using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_first_API.DTOs
{
    public class DepartmentStudentDTO
    {
        public List<StudentDTO> Students { get; set; }
    }
}