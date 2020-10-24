using Sociality.Data;
using Sociality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Services
{
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Title = model.Title,
                    Text = model.Text,
                    UserId = model.UserId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        //.Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                            new PostListItem
                            {
                                PostId = e.PostId,
                                Title = e.Title,
                                Text =e.Text,
                                //UserId = e.UserId,
                                TheUser = e.TheUser
                            }
                        );

                return query.ToArray();
                ;
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Posts
                       .Single(e => e.PostId == id);
                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        Title = entity.Title,
                        Text = entity.Text,
                        UserId = entity.UserId
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .Posts
                       .Single(e => e.PostId == model.PostId);

                entity.PostId = model.PostId;
                entity.Title = model.Title;
                entity.Text = model.Text;
                entity.UserId = model.UserId;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
