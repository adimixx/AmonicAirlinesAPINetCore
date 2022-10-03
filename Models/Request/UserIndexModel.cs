using Microsoft.AspNetCore.Mvc;

namespace AmonicAirlinesAPI.Models.Request
{
    public class UserIndexModel
    {
        [FromQuery(Name = "office_id")]
        public int OfficeId { get; set; } = 0;
    }
}
