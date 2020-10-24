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
        public Post LikedPost { get; set; }
        public TheUser Liker { get; set; }
    }
}
