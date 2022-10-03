using AmonicAirlinesAPI.Models;
using AmonicAirlinesAPI.Models.Request;
using AmonicAirlinesAPI.Models.View;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmonicAirlinesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AmonicAirlinesContext _context;
        public UsersController(AmonicAirlinesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserViewModel>>> Index([FromQuery] UserIndexModel model)
        {
            var Query = _context.Users.Include("Office").Include("Role").AsQueryable();

            if (model.OfficeId != 0)
            {
                Query = Query.Where(x => x.OfficeId == model.OfficeId);
            }

            return await Query.Select(x => new UserViewModel
            {
                Id = x.Id,
                Active = x.Active,
                Birthdate = x.Birthdate,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Office = x.Office.Title ?? null,
                OfficeId = x.OfficeId,
                Password = x.Password,
                Role = x.Role.Title,
                RoleId = x.RoleId
            }).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {

            }
        }
    }
}
