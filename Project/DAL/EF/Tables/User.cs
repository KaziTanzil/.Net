using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Tables
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required, MaxLength(150)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [Required, MaxLength(255)] 
        [Column(TypeName = "varchar")]
        public string PasswordHash { get; set; }

        [Required, MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
