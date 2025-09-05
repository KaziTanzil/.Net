using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsRegistration.DTOs
{
    public class SportsDTO
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public int Capacity { get; set; }
        public int Count { get; set; }
    }
}