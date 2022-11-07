using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    public class ContactPersonEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [Required, Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "char(16)")]
        public string? Phone { get; set; }

        [Column(TypeName = "char(16)")]
        public string? Mobile { get; set; }

        [Required]
        public int AddressId { get; set; }

        public AddressEntity Address { get; set; }
    }
}

