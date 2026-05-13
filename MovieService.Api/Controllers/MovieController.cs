using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace MovieService.Api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
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
        return Ok(movies);
    }

    [HttpPost("addMovies")]
    public IActionResult AddMovie(string title)
    {
        var movie = new { Id = 1, Title = title };
        return Ok(movie);
    }
}