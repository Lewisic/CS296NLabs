using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsaacLewisSite.Models;

namespace IsaacLewisSite.Repos
{
    public class StoryRepository : IStoryRepository
    {
        private ApplicationDbContext context;

        public StoryRepository(ApplicationDbContext c)
        {
            context = c;
        }

        public IQueryable<Story> Stories
        {
            get
            {
                return context.Stories.Include(story => story.User)
                                      .Include(story => story.Comments)
                                      .ThenInclude(comment => comment.Commenter);
            }
        }
        public async Task<Story?> GetStoryByIdAsync(int id)
        {
            return await Stories.Where(s => s.StoryID == id).FirstOrDefaultAsync();
        }
        public async Task<int> StoreStoryAsync(Story model)
        {
            model.SubmitDate = DateTime.Now.Date;
            context.Stories.Add(model);
            return await context.SaveChangesAsync();
        }

        public async Task UpdateStoryAsync(Story story)
        {
            context.Stories.Update(story);
            await context.SaveChangesAsync();
        }

        public async Task<int> DeleteStoryAsync(Story story)
        {
            var theStory = await context.Stories.FindAsync(story.StoryID);
            context.Stories.Remove(theStory);
            return await context.SaveChangesAsync();
        }
    }
}
