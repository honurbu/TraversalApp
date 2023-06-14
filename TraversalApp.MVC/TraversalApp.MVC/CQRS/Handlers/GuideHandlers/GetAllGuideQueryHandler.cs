using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalApp.MVC.CQRS.Queries.GuideQueries;
using TraversalApp.MVC.CQRS.Results.GuideResults;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery, List<GetAllGuideQueryResult>>
    {
        private readonly AppDbContext _context;

        public GetAllGuideQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                Id = x.Id,
                Description = x.Description,
                Image = x.Image,
                Name = x.Name
            }).AsNoTracking().ToListAsync();
        }
    }
}
