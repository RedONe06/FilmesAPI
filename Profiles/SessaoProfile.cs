using AutoMapper;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Data.DTO_s.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao*(-1))));
            CreateMap<UpdateSessaoDTO, Sessao>();
        }
        
    }
}
