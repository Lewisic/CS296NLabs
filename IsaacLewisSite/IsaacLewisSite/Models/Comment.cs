using System.ComponentModel.DataAnnotations;

namespace IsaacLewisSite.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 300)]
        public string CommentText { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/d/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime CommentDate { get; set; }
        public AppUser Commenter { get; set; }

        public int StoryID { get; set; }
    }
}
