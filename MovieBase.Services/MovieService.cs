using MovieBase.Data;
using MovieBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Services
{
    public class MovieService
    {
        private readonly Guid _userId;

        public MovieService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMovie(MovieCreate model)
        {
            var entity =
                 new Movie()
                 {
                     UserId = _userId,
                     Title = model.Title,
                     ReleaseDate = model.ReleaseDate,
                     Description = model.Description,
                     CoverPicture = model.CoverPicture,
                     TrailerLink = model.TrailerLink,
                     GenreName = model.GenreName

                 };

             using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Movies
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new MovieListItem
                                {
                                    MovieId = e.MovieId,
                                    Title = e.Title,
                                    ReleaseDate = e.ReleaseDate,
                                    Description = e.Description,
                                    CoverPicture = e.CoverPicture,
                                    TrailerLink = e.TrailerLink,
                                    GenreName = e.GenreName
                                }
                        );

                 return query.ToArray();
            }
        }

        public MovieDetail GetMovieById(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Movies
                        .Single(e => e.MovieId == noteId && e.UserId == _userId);
                return
                    new MovieDetail
                    {
                        MovieId = entity.MovieId,
                        Title = entity.Title,
                        ReleaseDate = entity.ReleaseDate,
                        Description = entity.Description,
                        CoverPicture = entity.CoverPicture,
                        TrailerLink = entity.TrailerLink,
                        GenreName = entity.GenreName
                    };
            }
        }
    }
}