using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Data
{
    public class Like
    {
        [Key]
        public Post LikedPost { get; set; }

        [Required]
        public User Liker { get; set; }
    }
}
