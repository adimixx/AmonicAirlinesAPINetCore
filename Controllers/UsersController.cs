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

        [HttpPut("{Id}")]
        public async Task<ActionResult<User>> PutUser([FromForm] User model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.OfficeId = model.OfficeId;
            user.RoleId = model.RoleId;

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
