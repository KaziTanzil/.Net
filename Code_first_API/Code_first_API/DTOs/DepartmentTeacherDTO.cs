using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Code_first_API.DTOs
{
    public class DepartmentTeacherDTO
    {
        public List<TeacherDTO> Teachers { get; set; }
    }
}