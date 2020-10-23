using Sociality.Data;
using Sociality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Hosting;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Services
{
    class UserService
    {
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity =
                new TheUser()
                {
                    Name = model.Name,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.TheUsers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<UserListItem> GetUsers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .TheUsers
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                            new UserListItem
                            {
                                UserId = e.UserId,
                                Name = e.Name,
                                Email = e.Email
                            }
                        );

                return query.ToArray();
                ;
            }
        }

        public UserDetail GetUserById(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .TheUsers
                       .Single(e => e.UserId == id);
                return
                    new UserDetail
                    {
                        UserId = entity.UserId,
                        Name = entity.Name,
                        Email = entity.Email
                    };
            }
        }

        public bool UpdateUser(UserEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                       .TheUsers
                       .Single(e => e.UserId == _userId);

                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .TheUsers
                        .Single(e => e.UserId == userId);

                ctx.TheUsers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
