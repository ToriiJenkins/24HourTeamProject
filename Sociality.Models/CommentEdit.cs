using Sociality.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Models
{
    public class CommentEdit
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public TheUser TheUser { get; set; }
        public Post Post { get; set; }
    }
}
