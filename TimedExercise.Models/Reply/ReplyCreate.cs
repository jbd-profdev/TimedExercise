using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace TimedExercise.Models.Reply
{
    public class ReplyCreate
    {   
        [MaxLength(256)]
        public string Text { get; set;} = string.Empty;
    }
}