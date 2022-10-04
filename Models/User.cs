using AmonicAirlinesAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmonicAirlinesAPI.Models
{
    public partial class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [FromForm(Name = "role_id")]
        public int RoleId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Unique(ErrorMessage = "Email address already exists")]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [FromForm(Name = "first_name")]
        public string? FirstName { get; set; }

        [Required]
        [FromForm(Name = "last_name")]
        public string LastName { get; set; } = null!;

        [Required]
        [FromForm(Name = "office_id")]
        public int? OfficeId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Birthdate { get; set; }
        public bool? Active { get; set; }

        public virtual Office? Office { get; set; }

        public virtual Role? Role { get; set; }

        public int Age
        {
            get
            {
                if (this.Birthdate.HasValue)
                    return DateTime.Now.Year - this.Birthdate.Value.Year;
                return 0;
            }
        }
    }
}
