using System.Collections.Generic;
using System.Threading.Tasks;
using TorchFireFilms.Api.Films.Data.Models;

namespace TorchFireFilms.Api.Films
{
    public interface IFilmsService
    {
        Task<IEnumerable<Data.Models.Film>> GetAllAsync(int languageId);
        Task<Film> GetByIdAsync(int id, int languageId);
        Task<Data.Models.Film> CreateAsync(Data.Models.Film film);
        Task<Data.Models.Film> UpdateAsync(Data.Models.Film film);
    }
}