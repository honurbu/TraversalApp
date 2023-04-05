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
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext context) : base(context)
        {
        }

        public IQueryable<Comment> GetDestinationById(int id)
        {
            return _context.Comments.Include(x => x.Destination);
        }

        public IQueryable<Comment> GetListCommentWithDestination()
        {
             return _context.Comments.Include(x => x.Destination);
        }
    }
}
