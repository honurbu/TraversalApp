using Microsoft.EntityFrameworkCore;
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
    public class DestinationRepository : GenericRepository<Destination>, IDestinationRepository
    {
        public DestinationRepository(AppDbContext context) : base(context)
        {
        }

        public Destination GetDestinationsWithGuide(int id)
        {
            return _context.Destinations.Where(x => x.Id == id).Include(x => x.Guide).FirstOrDefault();
        }

        public async Task<List<Destination>> GetLast4Destinations()
        {
            return await _context.Destinations.OrderByDescending(x => x.Id).Take(4).ToListAsync();
        }
    }
}
