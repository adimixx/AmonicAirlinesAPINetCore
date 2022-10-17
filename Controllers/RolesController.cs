using AmonicAirlinesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmonicAirlinesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private AmonicAirlinesContext _context;

        public RolesController(AmonicAirlinesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> Index()
        {
            var query = _context.Roles;
            return await query.ToListAsync();
        }
    }
}
