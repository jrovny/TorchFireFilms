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
            CreateMap<Data.Models.Film, Models.Film>()
                .ForMember(d => d.Title, opt => opt.MapFrom(f => f.FilmTranslation.Title))
                .ForMember(d => d.Description, opt => opt.MapFrom(f => f.FilmTranslation.Description));
        }
    }
}