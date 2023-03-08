using IsaacLewisSite.Models;
using IsaacLewisSite.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IsaacLewisSite.Controllers
{
    public class StoriesController : Controller
    {
        IStoryRepository repo;
        UserManager<AppUser> userManager;
        public StoriesController(IStoryRepository r, UserManager<AppUser> userMngr)
        {
            repo = r;
            userManager = userMngr;
        }
        
        public async Task<IActionResult> Index(string userName, string submitDate)
        {
            List<Story> stories;

            if (submitDate != null)
            {
                
                 stories = await (from r in repo.Stories where r.SubmitDate.Date == DateTime.Parse(submitDate).Date select r).ToListAsync<Story>();
            }
            else if (userName != null)
            {
                stories = await (from r in repo.Stories where r.User.UserName == userName select r).ToListAsync<Story>();
            }
            else
            {
                stories = repo.Stories.ToList<Story>();
            }
            return View(stories);
        }

        [Authorize]
        public IActionResult Story()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Story(Story model)
        {
            if (userManager != null) 
            {
                model.User = await userManager.GetUserAsync(User);
            }
            if (await repo.StoreStoryAsync(model) > 0) 
            {
                return RedirectToAction("Index", new { storyId = model.StoryID});
            }
            else
            {
                return View(); //add error message later
            }
        }

        [Authorize]
        public IActionResult Comment(int storyID)
        {
            var commentVM = new CommentVM { StoryID = storyID };
            return View(commentVM);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> Comment(CommentVM commentVM)
        {
            var comment = new Comment { CommentText = commentVM.CommentText };

            if (userManager != null)
            {
                comment.Commenter = await userManager.GetUserAsync(User);
                comment.Commenter.Name = comment.Commenter.UserName;
                comment.CommentDate = DateTime.Now;
            }

            var story = await repo.GetStoryByIdAsync(commentVM.StoryID);

            story.Comments.Add(comment);
            await repo.UpdateStoryAsync(story);

            return RedirectToAction("Index", new { userName = story.User});
        }
    }
}
