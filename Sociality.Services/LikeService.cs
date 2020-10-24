using Sociality.Data;
using Sociality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Services
{
    public class LikeService
    {
        private readonly Guid _userId;

        public LikeService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    PostId = model.PostId,
                    UserId = model.UserId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Likes
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                            new LikeListItem
                            {
                                PostId = e.PostId,
                                UserId = e.UserId
                            }
                        );

                return query.ToArray();
                ;
            }
        }

        public LikeDetail GetLikeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Likes
                       .Single(e => e.LikeId == id);
                return
                    new LikeDetail
                    {
                        LikedPost = entity.Post,
                        Liker = entity.TheUser
                    };
            }
        }

        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Likes
                       .Single(e => e.LikeId == model.LikeId);

                entity.PostId = model.PostId;
                entity.UserId = model.UserId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLike(int likeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeId == likeId);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
