using Sociality.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Models
{
    public class LikeListItem
    {
        public int PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
