using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Code_first_API.EF.Tables
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName="Varchar")]
        public string Name { get; set; }

        [ForeignKey("Dept")]
        public int DeptId {  get; set; }

        public virtual Department Dept { get; set; }

        

    }
}