using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalApp.Core.Entites;
using TraversalApp.Core.Repositories;
using TraversalApp.Core.Services;
using TraversalApp.Core.UnitOfWorks;

namespace TraversalApp.Service.Services
{
    public class CommentService : GenericServices<Comment>,ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(IGenericRepository<Comment> repository, IUnitOfWork unitOfWork, ICommentRepository commentRepository) : base(repository, unitOfWork)
        {
            _commentRepository = commentRepository;
        }

        public IQueryable<Comment> GetDestinationById(int id)
        {
            return _commentRepository.GetListByFilter(x=>x.DestinationId == id);
        }

        public IQueryable<Comment> GetListCommentWithDestination()
        {
            return _commentRepository.GetListCommentWithDestination();
        }
    }
}
