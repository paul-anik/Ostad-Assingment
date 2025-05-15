using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QnAApp.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Body { get; set; }

        public DateTime PostedAt { get; set; } = DateTime.Now;

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
