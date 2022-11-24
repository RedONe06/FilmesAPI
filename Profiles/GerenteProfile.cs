using AutoMapper;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Data.DTO_s.Gerente;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDTO, Gerente>();
            CreateMap<Gerente, ReadGerenteDTO>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas
                .Select(c => new { c.Id, c.Nome, c.Endereco, c.EnderecoFK})));
            CreateMap<UpdateGerenteDTO, Gerente>();

        }
    }
}
