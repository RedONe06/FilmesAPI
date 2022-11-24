using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s.Sessao;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class SessaoService
    {
        private IMapper _mapper;
        private AppDbContext _context;

        public SessaoService(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public ReadSessaoDTO AdicionarSessao(CreateSessaoDTO sessaoDTO)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDTO);
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            return _mapper.Map<ReadSessaoDTO>(sessao);
        }

        public ReadSessaoDTO RecuperarSessaoPorId(int id)
        {
            Sessao sessao = BuscarNoBancoPorId(id);
            if (sessao != null)
            {
                return _mapper.Map<ReadSessaoDTO>(sessao);
            }
            return null;
        }

        public Result DeletarSessao(int id)
        {
            Sessao sessao = BuscarNoBancoPorId(id);

            if (sessao == null)
            {
                return Result.Fail("Sessão não encontrada");
            }
            _context.Remove(sessao);
            _context.SaveChanges();
            return Result.Ok();
        }

        private Sessao BuscarNoBancoPorId(int id)
        {
            return _context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);
        }

        public Result AtualizarSessao(int id, UpdateSessaoDTO sessaoDTO)
        {
            Sessao sessao = BuscarNoBancoPorId(id);

            if (sessao == null)
            {
                return Result.Fail("Sessão não encontrada");
            }
            _mapper.Map(sessaoDTO, sessao);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
