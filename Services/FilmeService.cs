using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Services
{
    public class FilmeService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public FilmeService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadFilmeDTO AdicionarFilme(CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);

            _context.Filmes.Add(filme);
            _context.SaveChanges();
            return _mapper.Map<ReadFilmeDTO>(filme);
        }

        public List<ReadFilmeDTO> RecuperarFilmes(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
            {
                filmes = _context.Filmes.ToList();
            }
            else
            {
                filmes = _context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();
            }
            if (filmes != null)
            {
                List<ReadFilmeDTO> readDTO = _mapper.Map<List<ReadFilmeDTO>>(filmes);
                return readDTO;
            }
            return null;
        }

        public ReadFilmeDTO RecuperarFilmePorId(int id)
        {
            Filme filme = BuscarFilmePorIdNoBanco(id);

            if (filme != null)
            {
                ReadFilmeDTO filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);

                return filmeDTO;
            }
            return null;
        }

        public Result AtualizarFilme(int id, UpdateFilmeDTO filmeDTO)
        {
            Filme filme = BuscarFilmePorIdNoBanco(id);

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _mapper.Map(filmeDTO, filme);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Filme BuscarFilmePorIdNoBanco(int id)
        {
            return _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        }

        public Result DeletarFilme(int id)
        {
            Filme filme = BuscarFilmePorIdNoBanco(id);

            if (filme == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Remove(filme);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
