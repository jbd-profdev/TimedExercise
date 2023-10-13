using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimedExercise.Models.Like
{
    public class LikeCreate
    {
        [Required]
        public int PostId { get; set; }
        [Required]

        public int UserId { get; set; }
    }
}