using MediatR;
using TraversalApp.MVC.CQRS.Queries.GuideQueries;
using TraversalApp.MVC.CQRS.Results.DestinationResults;
using TraversalApp.MVC.CQRS.Results.GuideResults;
using TraversalApp.Repository.Context;

namespace TraversalApp.MVC.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly AppDbContext _context;

        public GetGuideByIDQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.Id);
            return new GetGuideByIDQueryResult
            {
                Id = values.Id,
                Description = values.Description,
                Name = values.Name,
            };
        }
    }
}
