using MovieService.Api.Data;
using MovieService.Api.Models;

namespace MovieService.Api.Services;

public class MovieServiceFile
{
    private readonly MovieDbContext _dbContext;

    public MovieServiceFile(MovieDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Retrieves a list of all movies from the database. This method is responsible for fetching all movie titles currently stored in the database.
    /// It uses a LINQ query to select the titles of all movies from the database context and returns them as a list of strings. 
    /// If there are no movies in the database, it will return an empty list. 
    /// This allows clients to easily retrieve a list of all available movies without needing to know the details of the database structure.
    /// </summary>
    /// <returns>A list of movie titles.</returns>
    public List<string> GetMovies()
    {
        var query = from m in _dbContext.Set<Movie>()
                    select m.Title;
        return query.ToList();
    }

    /// <summary>
    /// Adds a new movie to the database. This method is responsible for creating a new movie entry in the database based on the provided title.
    /// It creates a new Movie object with the given title, adds it to the database context, and saves the changes to the database. 
    /// Finally, it returns the newly added movie object, which includes the generated ID and the title. 
    /// This allows clients to receive confirmation of the added movie along with its details.
    /// </summary>
    /// <param name="title">The title of the movie to be added.</param>
    /// <returns>The newly added movie object.</returns>
    public Movie AddMovie(string title)
    {
        var movie = new Movie { Title = title };
        _dbContext.Set<Movie>().Add(movie);
        _dbContext.SaveChanges();
        return movie;
    }

    /// <summary>
    /// Retrieves a movie by its unique identifier (ID). This method is responsible for fetching a movie from the database based on its ID.
    /// It uses Entity Framework's Find method to locate the movie with the specified ID. 
    /// If the movie is found, it returns the movie object; otherwise, it returns null. 
    /// This allows clients to retrieve specific movie details by providing the movie's ID.
    /// </summary>
    /// <param name="id">The ID of the movie to be retrieved.</param>
    /// <returns>The movie object if found; otherwise, null.</returns>
    public Movie? GetMovieById(int id)
    {
        return _dbContext.Set<Movie>().Find(id);
    }

    /// <summary>
    /// Updates the title of an existing movie in the database. This method takes the unique identifier (ID) 
    /// of the movie to be updated and the new title as parameters.
    /// It creates a new Movie object with the provided ID and title, then updates the existing movie in the database using 
    /// Entity Framework's Update method. Finally, it saves the changes to the database.
    /// </summary>
    /// <param name="id">The ID of the movie to be updated.</param>
    /// <param name="title">The new title of the movie.</param>
    /// <returns>The updated movie object.</returns>
    public Movie UpdateMovie(int id, string title)
    {
        var movie = new Movie { Id = id, Title = title };
        _dbContext.Set<Movie>().Update(movie);
        _dbContext.SaveChanges();
        return movie;
    }

    /// <summary>
    /// Deletes a movie from the database. This method is responsible for removing a movie based on its unique identifier (ID).
    /// It first checks if the movie with the specified ID exists in the database. 
    /// If it does not exist, it returns a message indicating that the movie was not found. 
    /// If the movie exists, it deletes the movie and returns a success message.
    /// </summary>
    /// <param name="id">The ID of the movie to be deleted.</param>
    /// <returns>A message indicating the result of the delete operation.</returns>
    public string DeleteMovie(int id)
    {
        var movie = _dbContext.Set<Movie>().Find(id);
        if (movie == null)
        {
            return $"Movie with ID {id} not found.";
        }

        _dbContext.Set<Movie>().Remove(movie);
        _dbContext.SaveChanges();
        return $"Movie with ID {id} deleted successfully.";
    }
}