using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TorchFireFilms.Api.Films
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FilmsController> _logger;
        private readonly IMapper _mapper;

        public FilmsController(
            ApplicationDbContext context,
            ILogger<FilmsController> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Models.Film>> GetAllAsync(int languageId)
        {
            _logger.LogInformation("Getting all films by languageId {languageId}", languageId);

            if (languageId < 1)
                languageId = 1;

            return await _context.Films
                .Include(f => f.FilmTranslation)
                .AsNoTracking()
                .Where(f => f.FilmTranslation.IsoLanguage639Id == languageId)
                .Select(f => new Models.Film
                {
                    FilmId = f.FilmId,
                    Title = f.FilmTranslation.Title,
                    RuntimeMinutes = f.RuntimeMinutes,
                    ReleasedDate = f.ReleasedDate,
                    Uri = f.Uri,
                    Image = f.Image,
                    Thumbnail = f.Thumbnail
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, int languageId)
        {
            _logger.LogInformation("Getting film by id {id} and languageId {languageId}", id, languageId);

            if (languageId == 0)
                languageId = 1;

            var film = await _context.Films
                .Include(f => f.FilmTranslation)
                .AsNoTracking()
                .Where(f => f.FilmId == id)
                .Where(f => f.FilmTranslation.IsoLanguage639Id == languageId)
                .Select(f => new Models.Film
                {
                    FilmId = f.FilmId,
                    Title = f.FilmTranslation.Title,
                    Description = f.FilmTranslation.Description,
                    RuntimeMinutes = f.RuntimeMinutes,
                    ReleasedDate = f.ReleasedDate,
                    Uri = f.Uri,
                    Image = f.Image,
                    Thumbnail = f.Thumbnail
                })
                .FirstOrDefaultAsync();

            if (film == null)
                return NotFound();

            return Ok(film);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateFilmAsync(Models.FilmSave film)
        {
            var filmSave = _mapper.Map<Data.Models.Film>(film);

            _context.Films.Add(filmSave);
            await _context.SaveChangesAsync();
            film.FilmId = filmSave.FilmId;

            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = film.FilmId, languageId = film.IsoLanguage639Id },
                film);
        }
    }
}
