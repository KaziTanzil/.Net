using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace test1.Models
{
    public class From
    {
        [Required(ErrorMessage = "Name is required.")]
       [StringLength(20, ErrorMessage = "Name cannot be longer than 20 characters.")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Contain letters and spaces.")]
        public string Name { get; set; }
       

        
    }
}