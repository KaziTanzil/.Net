using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }


 

        [Required]
        [Column(TypeName = "varchar")]
        public double Amount { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string PaymentMethod { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        public DateTime PaymentDate { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string Status { get; set; }


        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
    }
}
