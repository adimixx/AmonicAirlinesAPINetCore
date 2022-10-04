using AmonicAirlinesAPI.Models;
using AmonicAirlinesAPI.Models.Request;
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
        public async Task<ActionResult<List<User>>> Index([FromQuery] UserIndexModel model)
        {
            var Query = _context.Users.Include("Office").Include("Role").AsQueryable();

            if (model.OfficeId != 0)
            {
                Query = Query.Where(x => x.OfficeId == model.OfficeId);
            }

            return await Query.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser([FromForm] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            model.RoleId = _context.Roles.Where(x => x.Title == "User").First().Id;
            model.Active = true;

            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return model;
        }
    }
}
