using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorchFireFilms.Api.Values;

namespace TorchFireFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Value>> GetAllAsync()
        {
            return await _context.Values.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _context.Values.AsNoTracking().Where(v => v.ValueId == id).FirstOrDefaultAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync(Value value)
        {
            _context.Values.Add(value);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = value.ValueId }, value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Value value)
        {
            _context.Values.Update(value);
            await _context.SaveChangesAsync();
            return Ok(value);
        }
    }
}
