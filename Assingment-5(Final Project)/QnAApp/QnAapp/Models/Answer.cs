using System;
using System.ComponentModel.DataAnnotations;

namespace QnAApp.Models
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PostedAt { get; set; } = DateTime.Now;

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
