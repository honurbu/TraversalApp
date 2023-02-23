using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Repository.Context;

namespace TraversalApp.Repository.Repositories
{
    public class About2Repository : GenericRepository<About2>, IAbout2Repository
    {
        public About2Repository(AppDbContext context) : base(context)
        {
        }
    }
}
