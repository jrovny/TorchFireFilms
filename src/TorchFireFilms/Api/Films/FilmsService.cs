using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TorchFireFilms.Api.Films
{
    public class FilmsService : IFilmsService
    {
        private readonly ApplicationDbContext _context;

        public FilmsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Data.Models.Film>> GetAllAsync(int languageId)
        {
            return await _context.Films
                .Include(f => f.FilmTranslation)
                .AsNoTracking()
                .Where(f => f.FilmTranslation.IsoLanguage639Id == languageId)
                .Where(f => f.Deleted == false)
                .ToListAsync();
        }

        public async Task<Data.Models.Film> GetByIdAsync(int id, int languageId)
        {
            return await _context.Films
                .Include(f => f.FilmTranslation)
                .AsNoTracking()
                .Where(f => f.FilmId == id)
                .Where(f => f.FilmTranslation.IsoLanguage639Id == languageId)
                .FirstOrDefaultAsync();
        }

        public async Task<Data.Models.Film> CreateAsync(Data.Models.Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();

            return film;
        }

        public async Task<Data.Models.Film> UpdateAsync(Data.Models.Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();

            return film;
        }
    }
}