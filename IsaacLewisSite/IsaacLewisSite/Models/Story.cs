using System;
using System.ComponentModel.DataAnnotations;

namespace IsaacLewisSite.Models
{
    public class Story
    {
        private List<Comment> comments = new();

        public int StoryID { get; set; }

        [Required]
        public string StoryTitle { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string StoryTopic { get; set; }

        public int StoryDate { get; set; }

        [Required]
        public string StoryText { get; set; }

        public AppUser? User { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime SubmitDate { get; set; }

        public ICollection<Comment> Comments => comments;
    }
}
