using MovieService.Api.Data;

namespace MovieService.Api.Services;

public class MovieService
{
    private readonly MovieDbContext _dbContext;

    public MovieService(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}