using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsRegistration.DTOs
{
    public class AdminDTO
    {
        public int AId { get; set; }
        public string AName { get; set; }
        public string AGmail { get; set; }
        public string APassword { get; set; }
    }
}