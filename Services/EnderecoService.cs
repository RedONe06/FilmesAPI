using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class EnderecoService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public EnderecoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDTO AdicionarEndereco(CreateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDTO);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return _mapper.Map<ReadEnderecoDTO>(endereco);
        }

        public IEnumerable<ReadEnderecoDTO> ResgatarEnderecos()
        {
            IEnumerable<ReadEnderecoDTO> enderecos = _mapper.Map<IEnumerable<ReadEnderecoDTO>>(_context.Enderecos);
            return enderecos;
        }

        public ReadEnderecoDTO ResgatarEnderecoPorId(int id)
        {
            Endereco endereco = BuscarNoBancoPorId(id);

            if (endereco != null)
            {
                return _mapper.Map<ReadEnderecoDTO>(endereco);
            }
            return null;

        }

        private Endereco BuscarNoBancoPorId(int id)
        {
            return _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        }

        public Result AtualizarEndereco(int id, UpdateEnderecoDTO enderecoDTO)
        {
            Endereco endereco = BuscarNoBancoPorId(id);
            if (endereco == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _mapper.Map(enderecoDTO, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarEndereco(int id)
        {
            Endereco endereco = BuscarNoBancoPorId(id);
            if (endereco == null)
            {
                return Result.Fail("Endereço não encontrado");
            }
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
