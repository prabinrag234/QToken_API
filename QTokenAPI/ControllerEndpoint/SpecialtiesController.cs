using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QTokenAPI.DBContext;
using QTokenAPI.EntityModels;

namespace QTokenAPI.ControllerEndpoint
{
    [Route("api/specialties")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly QTokenDBContext _context;

        public SpecialtiesController(QTokenDBContext context)
        {
            _context = context;
        }

        // GET: api/specialties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialty>>> GetSpecialties()
        {
            return await _context.Specialties.ToListAsync();
        }
    }

}
