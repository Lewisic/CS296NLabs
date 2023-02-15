using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsaacLewisSite.Models;
using IsaacLewisSite.Repos;

namespace IsaacLewisSite.Repos
{
    public class FakeStoryRepository : IStoryRepository
    {
        List<Story> stories = new List<Story>();

        public IQueryable<Story> Stories
        {
            get { return stories.AsQueryable<Story>(); }
        }

        public async Task<int> StoreStoryAsync(Story model)
        {
            int status = 0;
            if (model != null)
            {
                model.StoryID = stories.Count + 1;
                stories.Add(model);
                status = 1;
            }
            return status;
        }
    }
}
