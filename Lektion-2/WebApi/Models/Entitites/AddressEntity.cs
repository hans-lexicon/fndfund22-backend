using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models.Entitites
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; }

        [Required, Column(TypeName = "char(5)")]
        public string PostalCode { get; set; }

        [Required, Column(TypeName = "nvarchar(50)")]
        public string City { get; set; }

        public ICollection<ContactPersonEntity> ContactPersons { get; set; }
    }
}
