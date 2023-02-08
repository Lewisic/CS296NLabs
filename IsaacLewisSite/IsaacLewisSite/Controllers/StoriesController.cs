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
        
        public IActionResult Index(string userName, string submitDate)
        {
            List<Story> stories;

            if (submitDate != null)
            {
                
                stories = (from r in repo.Stories where r.SubmitDate.Date == DateTime.Parse(submitDate).Date select r).ToList<Story>();
            }
            else if (userName != null)
            {
                stories = (from r in repo.Stories where r.User.UserName == userName select r).ToList<Story>();
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
        public IActionResult Story(Story model)
        {
            model.User = userManager.GetUserAsync(User).Result;
            model.SubmitDate = DateTime.Now.Date;
            repo.AddStory(model);
            return RedirectToAction("Index", View(model));
            //return View(model);
        }

    }
}
