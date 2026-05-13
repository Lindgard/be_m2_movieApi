using MovieService.Api.Models;
using MovieService.Api.Services.Interfaces;
using MovieService.Api.Data;
namespace MovieService.Api.Repositories;

public class EfMovieRepository : IMovieRepository
{
    private readonly MovieDbContext _dbContext;

    public EfMovieRepository(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Movie AddMovie(string title)
    {
        var movie = new Movie { Title = title };
        _dbContext.Set<Movie>().Add(movie);
        _dbContext.SaveChanges();
        return movie;
    }

    public IEnumerable<Movie> GetMovies()
    {
        return _dbContext.Set<Movie>().ToList();
    }

    public Movie? GetMovieById(int id)
    {
        return _dbContext.Set<Movie>().Find(id);
    }

    public void DeleteMovie(int id)
    {
        var movie = new Movie { Id = id };
        _dbContext.Set<Movie>().Remove(movie);
        _dbContext.SaveChanges();
    }

    public Movie UpdateMovie(int id, string title)
    {
        var movie = new Movie { Id = id, Title = title };
        _dbContext.Set<Movie>().Update(movie);
        _dbContext.SaveChanges();
        return movie;
    }
}