﻿using Sociality.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sociality.Models
{
    public class LikeCreate
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
