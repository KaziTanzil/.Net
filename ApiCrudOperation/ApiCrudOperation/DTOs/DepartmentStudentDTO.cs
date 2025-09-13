using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiCrudOperation.DTOs
{
    public class DepartmentStudentDTO
    {
        public List<StudentDTO> Students { get; set; }
    }
}