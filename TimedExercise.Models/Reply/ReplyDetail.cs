using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimedExercise.Models.Reply
{
    public class ReplyDetail
    {
        [Key] 
        public int Id { get; set; }
        [MaxLength(256)]
        public string Text { get; set;} = string.Empty;
        [ForeignKey("User")]
        public int AuthorId { get; set; }
        [ForeignKey("comment")]
        public int ParentId { get; set; }
    }
}