using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Data.DTO_s.Gerente;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class GerenteService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public GerenteService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadGerenteDTO AdicionarGerente(CreateGerenteDTO gerenteDTO)
        {
            Gerente gerente = _mapper.Map<Gerente>(gerenteDTO);
            _context.Gerente.Add(gerente);
            _context.SaveChanges();
            return _mapper.Map<ReadGerenteDTO>(gerente);
        }

        public ReadGerenteDTO RecuperarGerentePorId(int id)
        {
            Gerente gerente = BuscarNoBancoPorId(id);
            if (gerente != null)
            {
                return _mapper.Map<ReadGerenteDTO>(gerente);
            }
            return null;
        }

        public IEnumerable<ReadGerenteDTO> RecuperarGerentes()
        {
            IEnumerable<ReadGerenteDTO> enderecos = _mapper.Map<IEnumerable<ReadGerenteDTO>>(_context.Enderecos);
            return enderecos;
        }

        public Result AtualizarGerente(int id, UpdateGerenteDTO gerenteDTO)
        {
            Gerente gerente = BuscarNoBancoPorId(id);

            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _mapper.Map(gerenteDTO, gerente);
            _context.SaveChanges();
            return Result.Ok();
        }

        private Gerente BuscarNoBancoPorId(int id)
        {
            return _context.Gerente.FirstOrDefault(gerente => gerente.Id == id);
        }

        public Result DeletarGerente(int id)
        {
            Gerente gerente = BuscarNoBancoPorId(id);

            if (gerente == null)
            {
                return Result.Fail("Gerente não encontrado");
            }
            _context.Remove(gerente);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
