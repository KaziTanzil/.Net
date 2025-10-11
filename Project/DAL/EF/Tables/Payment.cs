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
        public int OrderId { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
