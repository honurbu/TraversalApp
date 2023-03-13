using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;

namespace TraversalApp.Core.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        IQueryable<Comment> GetDestinationById(int id);

    }
}
