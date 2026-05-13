using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace MovieService.Api.Controllers;

[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
public class MovieController : ControllerBase
{
    [HttpGet]
    public IActionResult GetMovies()
    {
        var movies = new List<string>
        {
            "Star Wars",
            "The Lord of the Rings",
            "The Matrix",
            "Inception",
            "The Dark Knight"
        };
        return Ok(movies);
    }
}