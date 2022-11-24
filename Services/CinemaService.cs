using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.DTO_s;
using FilmesAPI.Models;
using FluentResults;

namespace FilmesAPI.Services
{
    public class CinemaService
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public CinemaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadCinemaDTO AdicionarCinema(CreateCinemaDTO cinemaDTO)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDTO);

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            return _mapper.Map<ReadCinemaDTO>(cinema);
        }

        public List<ReadCinemaDTO> RecuperarCinemas(string nomeDoFilme)
        {
            List<Cinema> cinemas = _context.Cinemas.ToList();

            if (cinemas == null)
            {
                return null;
            }
            if (string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema
                                            in cinemas
                                            where cinema.Sessoes.Any(sessao => sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;
                cinemas = query.ToList();
            }
            List<ReadCinemaDTO> readDTO = _mapper.Map<List<ReadCinemaDTO>>(cinemas);
            return readDTO;
        }

        public ReadCinemaDTO RecuperarCinemaPorId(int id)
        {
            Cinema cinema = BuscarCinemaPorIdNoBanco(id);

            if (cinema != null)
            {
                ReadCinemaDTO cinemaDTO = _mapper.Map<ReadCinemaDTO>(cinema);

                return cinemaDTO;
            }
            return null;
        }

        public Result AtualizarCinema(int id, UpdateCinemaDTO cinemaDTO)
        {
            Cinema cinema = BuscarCinemaPorIdNoBanco(id);

            if (cinema == null)
            {
                return Result.Fail("Cinema não encontrado");
            }
            _mapper.Map(cinemaDTO, cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletarCinema(int id)
        {
            Cinema cinema = BuscarCinemaPorIdNoBanco(id);

            if (cinema == null)
            {
                return Result.Fail("Filme não encontrado");
            }
            _context.Remove(cinema);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Cinema BuscarCinemaPorIdNoBanco(int id)
        {
            return _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);
        }
    }
}
