using Microsoft.AspNetCore.Mvc;
using MovieService.Api.Models;
using MovieService.Api.Services;
namespace MovieService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieServiceFile _movieService;
    public MovieController(MovieServiceFile movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// Retrieves a list of all movies from the database. This endpoint allows clients to fetch a list of all movies currently stored in the database. 
    /// The client must send a GET request to this endpoint, and it will return a list of movie titles along with a success status code. 
    /// If there are no movies in the database, an empty list will be returned.
    /// </summary>
    /// <returns>An ApiResponse containing the list of movies.</returns>
    [HttpGet("movies")]
    public IActionResult GetMovies()
    {
        var movies = _movieService.GetMovies();
        return Ok(new ApiResponse<List<string>> { Data = movies, StatusCode = 200 });
    }

    /// <summary>
    /// Adds a new movie to the database. This endpoint allows clients to add a new movie by providing its title. 
    /// The client must send a POST request with the movie title as a parameter. 
    /// If the movie is added successfully, the endpoint will return the details of the newly added movie along with a success status code.
    /// </summary>
    /// <param name="title">The title of the movie to be added.</param>
    /// <returns>An ApiResponse containing the details of the newly added movie.</returns>
    [HttpPost("addMovies")]
    public IActionResult AddMovie(string title)
    {
        var movie = _movieService.AddMovie(title);
        return Ok(new ApiResponse<object> { Data = movie, StatusCode = 201 });
    }

    [HttpGet("getMovieById")]
    public IActionResult GetMoviesById(int id)
    {
        var movie = _movieService.GetMovieById(id);
        return Ok(new ApiResponse<object> { Data = movie, StatusCode = 200 });
    }

    /// <summary>
    /// Deletes a movie from the database. This endpoint allows clients to delete a movie by providing its unique identifier (ID). 
    /// The client must send a DELETE request with the movie ID as a parameter. 
    /// If the movie is deleted successfully, the endpoint will return a success message along with a success status code. 
    /// If the movie with the specified ID does not exist, an appropriate error message will be returned.
    /// </summary>
    /// <param name="id">The ID of the movie to be deleted.</param>
    /// <returns>An ApiResponse indicating the result of the delete operation.</returns>
    [HttpDelete("deleteMovie")]
    public IActionResult DeleteMovie(int id)
    {
        var result = _movieService.DeleteMovie(id);
        return Ok(new ApiResponse<string> { Data = result, StatusCode = 200 });
    }
}