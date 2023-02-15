﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IsaacLewisSite.Models;

namespace IsaacLewisSite.Repos
{
    public interface IStoryRepository
    {
        IQueryable<Story> Stories { get; }
        public Task<int> StoreStoryAsync(Story model);
    }
}
