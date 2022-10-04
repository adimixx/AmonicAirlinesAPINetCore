using Newtonsoft.Json;

namespace AmonicAirlinesAPI.Models
{
    public partial class Office
    {
        public Office()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Title { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Contact { get; set; } = null!;

        [JsonIgnore]
        public virtual Country Country { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
