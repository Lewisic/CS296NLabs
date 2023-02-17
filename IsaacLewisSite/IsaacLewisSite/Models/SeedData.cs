using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacLewisSite.Models
{
    public class SeedData
    {
        public static void Seed(ApplicationDbContext context, IServiceProvider provider)
        {
            
            if (!context.Stories.Any())
            {
                var userManager = provider.GetRequiredService<UserManager<AppUser>>();
                const string SECRET_PASSWORD = "Super_Secret";
                AppUser isaac = new AppUser { UserName = "IsaacLewis" };
                var result = userManager.CreateAsync(isaac, SECRET_PASSWORD);
                AppUser luke = new AppUser { UserName = "LukeSkywalker" };
                result = userManager.CreateAsync(luke, SECRET_PASSWORD);
                context.SaveChanges();

                Story story = new Story
                {
                    StoryTitle = "Rogue One",
                    StoryTopic = "Death Star Plans",
                    StoryDate = 0,
                    StoryText = "A group of rebels steal the death star plans",
                    User = isaac,
                    SubmitDate = DateTime.Parse("11/2/2022")
                };
                context.Stories.Add(story);

                story = new Story
                {
                    StoryTitle = "Revenge of the Sith",
                    StoryTopic = "The fall of the jedi",
                    StoryDate = -18,
                    StoryText = "The fall of Anakin Skywalker",
                    User = isaac,
                    SubmitDate = DateTime.Parse("11/3/2022")
                };
                context.Stories.Add(story);

                story = new Story
                {
                    StoryTitle = "A New Hope",
                    StoryTopic = "A new hope has appeared",
                    StoryDate = 0,
                    StoryText = "The start of Lukes journey",
                    User = luke,
                    SubmitDate = DateTime.Parse("11/16/2022")
                };
                context.Stories.Add(story);

                context.SaveChanges();
            
            }
        }
    }
}
