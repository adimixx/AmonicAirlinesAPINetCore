using AmonicAirlinesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmonicAirlinesAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private AmonicAirlinesContext _amonicAirlinesContext;
        public CountriesController(AmonicAirlinesContext amonicAirlinesContext)
        {
            _amonicAirlinesContext = amonicAirlinesContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Country>>> Index()
        {
            var query = await _amonicAirlinesContext.Countries.ToListAsync();
            return Ok(query);
        }
    }
}
