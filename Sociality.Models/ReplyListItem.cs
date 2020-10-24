using Sociality.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Models
{
    public class ReplyListItem
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public TheUser Author { get; set; }
        public Post CommentPost { get; set; }
        public Comment ReplyComment { get; set; }
    }
}
