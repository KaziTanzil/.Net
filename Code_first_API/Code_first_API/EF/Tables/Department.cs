using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Code_first_API.EF.Tables
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName="varchar")]
        public string Name { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }

       
    }
}