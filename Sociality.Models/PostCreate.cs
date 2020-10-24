using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sociality.Data;

namespace Sociality.Models
{
    public class PostCreate
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public TheUser Author { get; set; }
    }
}
