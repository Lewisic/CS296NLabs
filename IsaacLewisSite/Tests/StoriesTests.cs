using IsaacLewisSite.Models;
using IsaacLewisSite.Controllers;
using IsaacLewisSite.Repos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO.MemoryMappedFiles;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class StoriesTests
    {
        IStoryRepository repo = new FakeStoryRepository();
        StoriesController controller;

        public StoriesTests()
        {
            controller = new StoriesController(repo, null);
        }

        [Fact]
          public void StoreStoryTest()
          {
              /*var story = new Story()
              {
                  StoryTitle = "Testing1",
                  StoryTopic = "Really good testing",
                  StoryDate = 1000,
                  StoryText = "The epic story of testing",
                  User = new AppUser() { UserName = "Isaac Lewis" }
              };

              controller.Story(story);

              var retrievedItem = repo.Stories.ToList()[0];
              Assert.Equal(retrievedItem.StoryTitle, "Testing1");*/

            var result = controller.Story(new Story { });
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }

          /*[Fact]
          public void StoryDateFilterTest()
          {
              var story = new Story()
              {
                  StoryTitle = "Testing1",
                  StoryTopic = "Really good testing",
                  StoryDate = 1000,
                  StoryText = "The epic story of testing",
                  User = new AppUser() { UserName = "Isaac Lewis" }
              };

              controller.Story(story);

              story = new Story()
              {
                  StoryTitle = "Testing2",
                  StoryTopic = "Really good testing",
                  StoryDate = 1000,
                  StoryText = "The epic story of testing",
                  User = new AppUser() { UserName = "Isaac Lewis" }
              };
              controller.Story(story);

              story = new Story()
              {
                  StoryTitle = "Testing3",
                  StoryTopic = "Really good testing",
                  StoryDate = 1000,
                  StoryText = "The epic story of testing",
                  User = new AppUser() { UserName = "Randomer" }
              };
              controller.Story(story);
              var date = "1/23/2023";
              var viewResult = (ViewResult)controller.Index(null, date);

              var stories = (List<Story>)viewResult.ViewData.Model;

              Assert.Equal(3, stories.Count);
              Assert.Equal(stories[0].StoryTitle, "Testing1");
          }

          [Fact]
          public void StoryUserNameFilterTest()
          {
              var story = new Story()
              {
                  StoryTitle = "Testing1",
                  StoryTopic = "Really good testing",
                  StoryDate = 1000,
                  StoryText = "The epic story of testing",
                  User = new AppUser() { UserName = "Isaac Lewis" }
              };

              controller.Story(story);

              story = new Story()
              {
                  StoryTitle = "Testing2",
                  StoryTopic = "Really good testing",
                  StoryDate = 1000,
                  StoryText = "The epic story of testing",
                  User = new AppUser() { UserName = "Isaac Lewis" }
              };
              controller.Story(story);

              story = new Story()
              {
                  StoryTitle = "Testing3",
                  StoryTopic = "Really good testing",
                  StoryDate = 1000,
                  StoryText = "The epic story of testing",
                  User = new AppUser() { UserName = "Randomer" }
              };
              controller.Story(story);

              var viewResult = (ViewResult)controller.Index("Isaac Lewis", null);

              var stories = (List<Story>)viewResult.ViewData.Model;

              Assert.Equal(2, stories.Count);
              Assert.Equal(stories[0].StoryTitle, "Testing1");
              Assert.Equal(stories[0].User.UserName, "Isaac Lewis");
          }*/
    }
}
