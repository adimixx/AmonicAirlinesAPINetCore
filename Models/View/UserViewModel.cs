using System.Runtime.Serialization;

namespace AmonicAirlinesAPI.Models.View
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public int? OfficeId { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool? Active { get; set; }
        public string? Office { get; set; }
        public string Role { get; set; } = null!;

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
