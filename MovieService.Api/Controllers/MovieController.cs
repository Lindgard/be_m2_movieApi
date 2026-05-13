using Microsoft.AspNetCore.Mvc;
using MovieService.Api.Models;
namespace MovieService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    [HttpGet("movies")]
    public IActionResult GetMovies()
    {
        var movies = new List<string>
        {
            "The Shawshank Redemption",
            "The Godfather",
            "The Dark Knight",
            "Pulp Fiction",
            "The Lord of the Rings: The Return of the King"
        };
        return Ok(new ApiResponse<List<string>> { Data = movies, StatusCode = 200 });
    }

    [HttpPost("addMovies")]
    public IActionResult AddMovie(string title)
    {
        var movie = new { Id = 1, Title = title };
        return Ok(new ApiResponse<object> { Data = movie, StatusCode = 200 });
    }
}