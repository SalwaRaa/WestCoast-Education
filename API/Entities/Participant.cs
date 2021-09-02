using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("Participant", Schema = "Participants")]
    public class Participant
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(15)")]
        public string FirstName { get; set; }

        [Column(TypeName = "VARCHAR(30)")]
        public string LastName { get; set; }

        [Column(TypeName = "VARCHAR(60)")]

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        [Column(TypeName = "VARCHAR(60)")]

        public string Address { get; set; }
    }
}