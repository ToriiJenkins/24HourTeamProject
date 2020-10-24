using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Data
{
    public class Reply: Comment
    {
        [Required]
        public Comment ReplyComment { get; set; }

    }
}
