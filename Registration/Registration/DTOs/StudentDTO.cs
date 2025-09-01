using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.DTOs
{
    public class StudentDTO
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public string SGmail { get; set; }
        public string SPassword { get; set; }
    }
}