using MovieBase.Data;
using MovieBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Services
{
    public class AppearanceService
    {
        private readonly Guid _userId;

        public AppearanceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAppearance(AppearanceCreate model)
        {
            var entity =
                 new Appearance()
                 {
                     UserId = _userId,
                     ActorId = model.ActorId,
                     MovieId = model.MovieId
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Appearances.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AppearanceListItem> GetAppearances()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Appearances
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new AppearanceListItem
                                {
                                    AppearanceId = e.AppearanceId,
                                    Actor = e.Actor,
                                    Movie = e.Movie
                                }
                        );

                return query.ToArray();
            }
        }
        public List<Actor> Actors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Actors.ToList();
            }
        }
        public List<Movie> Movies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Movies.ToList();
            }
        }

        public AppearanceDetail GetAppearanceById(int appearanceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appearances
                        .Single(e => e.AppearanceId == appearanceId && e.UserId == _userId);
                return
                    new AppearanceDetail
                    {
                        ActorId = entity.ActorId,
                        MovieId = entity.MovieId
                    };
            }
        }

        public bool UpdateAppearance(AppearanceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appearances
                        .Single(e => e.AppearanceId == model.AppearanceId && e.UserId == _userId);

                entity.ActorId = model.ActorId;
                entity.MovieId = model.MovieId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppearance(int appearanceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appearances
                        .Single(e => e.AppearanceId == appearanceId && e.UserId == _userId);
                ctx.Appearances.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
