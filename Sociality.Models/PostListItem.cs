using Sociality.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public TheUser Author { get; set; }
    }
}
