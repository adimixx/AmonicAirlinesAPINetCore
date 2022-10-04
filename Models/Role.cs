using Newtonsoft.Json;

namespace AmonicAirlinesAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
