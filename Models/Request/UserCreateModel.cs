using System.ComponentModel.DataAnnotations;

namespace AmonicAirlinesAPI.Models.Request
{
    public class UserCreateModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        public int? OfficeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }      
    }
}
