using MovieService.Api.Data;
using MovieService.Api.Models;

namespace MovieService.Api.Services;

public class MovieService
{
    private readonly MovieDbContext _dbContext;

    public MovieService(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<string> GetMovies()
    {
        var query = from m in _dbContext.Set<Movie>()
                    select m.Title;
        return query.ToList();
    }

    public Movie AddMovie(string title)
    {
        var movie = new Movie { Title = title };
        _dbContext.Set<Movie>().Add(movie);
        _dbContext.SaveChanges();
        return movie;
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