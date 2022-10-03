using AmonicAirlinesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmonicAirlinesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private AmonicAirlinesContext _context;

        public OfficesController(AmonicAirlinesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Office>>> Index()
        {
            var query = await _context.Offices.ToListAsync();
            return Ok(query);
        }
    }
}
