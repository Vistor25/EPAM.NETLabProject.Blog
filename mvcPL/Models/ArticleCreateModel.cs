using System;
using System.ComponentModel.DataAnnotations;

namespace mvcPL.Models
{
    public class ArticleCreateModel
    {
        [ScaffoldColumn(false)]
        public DateTime CreationDate { get; set; }

        [ScaffoldColumn(false)]
        public long UserId { get; set; }

        public long ID { get; set; }

        [Required(ErrorMessage = "Enter your title")]
        public string Title { get; set; }

        public string Content { get; set; }
        public string Tags { get; set; }
    }
}