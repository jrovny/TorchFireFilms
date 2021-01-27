using AutoMapper;

namespace TorchFireFilms.Api.Films
{
    public class FilmsMappingConfiguration : Profile
    {
        public FilmsMappingConfiguration()
        {
            CreateMap<Models.FilmSave, Data.Models.Film>()
                .ForMember(data => data.FilmTranslation, opt =>
                {
                    opt.MapFrom(s => new Data.Models.FilmI18n
                    {
                        FilmId = s.FilmId,
                        Title = s.Title,
                        Description = s.Description,
                        IsoLanguage639Id = s.IsoLanguage639Id
                    });
                });
        }
    }
}