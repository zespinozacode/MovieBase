using MovieBase.Data;
using MovieBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBase.Services
{
    public class ActorService
    {
        private readonly Guid _userId;

        public ActorService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateActor(ActorCreate model)
        {
            var entity =
                 new Actor()
                 {
                     UserId = _userId,
                     Name = model.Name

                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Actors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ActorListItem> GetActors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Actors
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ActorListItem
                                {
                                    ActorId = e.ActorId,
                                    Name = e.Name
                                }
                        );

                return query.ToArray();
            }
        }

        public ActorDetail GetActorById(int actorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Actors
                        .Single(e => e.ActorId == actorId && e.UserId == _userId);
                return
                    new ActorDetail
                    {
                        ActorId = entity.ActorId,
                        Name = entity.Name
                    };
            }
        }

        public bool UpdateActor(ActorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Actors
                        .Single(e => e.ActorId == model.ActorId && e.UserId == _userId);

                entity.ActorId = model.ActorId;
                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteActor(int actorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Actors
                        .Single(e => e.ActorId == actorId && e.UserId == _userId);
                ctx.Actors.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
