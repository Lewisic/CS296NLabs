﻿using System;

namespace IsaacLewisSite.Models
{
    public class Story
    {
        private List<Comment> comments = new();

        public int StoryID { get; set; }
        public string StoryTitle { get; set; }
        public string StoryTopic { get; set; }
        public int StoryDate { get; set; }
        public string StoryText { get; set; }
        public AppUser User { get; set; }
        public DateTime SubmitDate { get; set; }

        public ICollection<Comment> Comments => comments;
    }
}
