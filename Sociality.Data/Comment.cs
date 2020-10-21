using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public User Author { get; set; }

        [Required]
        public Post CommentPost { get; set; }

    }
}
