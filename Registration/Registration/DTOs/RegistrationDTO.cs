using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Registration.DTOs
{
    public class RegistrationDTO
    {
        public int RId { get; set; }
        public Nullable<int> CId { get; set; }
        public Nullable<int> SId { get; set; }
    }
}