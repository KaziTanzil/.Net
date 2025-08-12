using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Web;
using System.Web.ModelBinding;

namespace FormSubmission.Models
{
    public class Form
    {
        [Required]
        [StringLength(32)]
        public string Name { get; set; }

        [Required]
        [Range(1, 100)]
        public int? Id { get; set; }

        [Required]
        [EmailAddress]
        public string Gmail { get; set; }


        [Required]

        public DateTime DOB { get; set; }

        [Required]
        public string Address { get; set; }

        
        public int? Age
        {
            get
            {
                if (DOB == DateTime.Now)
                    return null;
                var age = DateTime.Now.Year - DOB.Year;
                if (DateTime.Now < DOB.AddYears(age))
                    age--;
                if (age < 18 || age > 100)
                    return null;
                //ErrorMessage="Age must be 18+";
                return age;
            }
        }


        //public string ErrorMessage { get; private set; }




        [Required]
        public string Gender { get; set; }

        [Required(ErrorMessage = "No hobby selected")]
        public string[] Hobbies { get; set; }


        public Form()
        {
            DOB = DateTime.Now;


        }

    }
}