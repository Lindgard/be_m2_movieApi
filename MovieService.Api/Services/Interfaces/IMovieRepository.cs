using MovieService.Api.Models;

namespace MovieService.Api.Services.Interfaces;

public interface IMovieRepository
{
    IEnumerable<Movie> GetMovies();
    Movie AddMovie(string title);
    Movie? GetMovieById(int id);
    void DeleteMovie(int id);
    Movie UpdateMovie(int id, string title);
}