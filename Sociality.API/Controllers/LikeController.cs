using Microsoft.AspNet.Identity;
using Sociality.Models;
using Sociality.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sociality.API.Controllers
{
    [Authorize]
    public class LikeController : ApiController
    {
        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var likeService = new LikeService(userId);
            return likeService;
        }

        public IHttpActionResult Get()
        {
            LikeService likeService = CreateLikeService();
            var likes = likeService.GetLikes();
            return Ok(likes);
        }

        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.CreateLike(like))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LikeEdit like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.UpdateLike(like))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateLikeService();

            if (!service.DeleteLike(id))
                return InternalServerError();

            return Ok();
        }
    }
}
