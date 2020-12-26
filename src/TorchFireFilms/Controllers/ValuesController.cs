using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
    }
}
