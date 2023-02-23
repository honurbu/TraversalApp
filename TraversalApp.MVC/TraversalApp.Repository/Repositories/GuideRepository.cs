﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Repository.Context;

namespace TraversalApp.Repository.Repositories
{
    public class GuideRepository : GenericRepository<Guide>, IGuideRepository
    {
        public GuideRepository(AppDbContext context) : base(context)
        {
        }
    }
}
