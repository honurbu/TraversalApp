using MediatR;
using TraversalApp.MVC.CQRS.Results.GuideResults;

namespace TraversalApp.MVC.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {
    }
}
