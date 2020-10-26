using Sociality.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Models
{
    public class LikeEdit
    {
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public Post LikedPost { get; set; }
        public Guid UserId { get; set; }
        public TheUser Liker { get; set; }
    }
}
