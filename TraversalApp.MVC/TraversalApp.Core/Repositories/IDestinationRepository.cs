using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Core.Repositories
{
    public interface IDestinationRepository : IGenericRepository<Destination>
    {
        Destination GetDestinationsWithGuide(int id);
        Task<List<Destination>> GetLast4Destinations();
    }
}
