using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TorchFireFilms.Api.Films
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ILogger<FilmsController> _logger;
        private readonly IMapper _mapper;
        private readonly IFilmsService _filmsService;

        public FilmsController(
            ILogger<FilmsController> logger,
            IMapper mapper,
            IFilmsService filmsService)
        {
            _logger = logger;
            _mapper = mapper;
            _filmsService = filmsService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Models.Film>> GetAllAsync(int languageId)
        {
            _logger.LogInformation("Getting all films by languageId {languageId}", languageId);

            if (languageId < 1)
                languageId = 1;

            return _mapper.Map<IEnumerable<Models.Film>>(
                await _filmsService.GetAllAsync(languageId)
            );
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, int languageId)
        {
            _logger.LogInformation("Getting film by id {id} and languageId {languageId}", id, languageId);

            if (languageId == 0)
                languageId = 1;

            var film = _mapper.Map<Models.Film>(await _filmsService.GetByIdAsync(id, languageId));

            if (film == null)
                return NotFound();

            return Ok(film);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilmAsync(Models.FilmSave film)
        {
            var filmSave = await _filmsService.CreateAsync(_mapper.Map<Data.Models.Film>(film));
            film.FilmId = filmSave.FilmId;

            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = film.FilmId, languageId = film.IsoLanguage639Id },
                film);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilmAsync(int id, Models.FilmSave film)
        {
            if (id != film.FilmId)
                return BadRequest(new ProblemDetails
                {
                    Title = "ID Mismatch",
                    Detail = "The ID in the URL does not match the ID in the body of the request.",
                    Instance = HttpContext.TraceIdentifier
                });

            var filmDb = await _filmsService.GetByIdAsync(id, film.IsoLanguage639Id);
            if (filmDb == null)
                return NotFound();

            var filmSave = await _filmsService.UpdateAsync(_mapper.Map<Data.Models.Film>(film));
            filmSave.FilmTranslation.FilmI18nId = filmDb.FilmTranslation.FilmI18nId;

            return Ok(film);
        }
    }
}
