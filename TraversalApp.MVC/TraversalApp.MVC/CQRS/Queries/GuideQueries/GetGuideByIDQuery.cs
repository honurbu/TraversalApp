using MediatR;
using TraversalApp.MVC.CQRS.Results.GuideResults;

namespace TraversalApp.MVC.CQRS.Queries.GuideQueries
{
    public class GetGuideByIDQuery:IRequest<GetGuideByIDQueryResult>
    {
        public int Id { get; set; }

        public GetGuideByIDQuery(int id)
        {
            Id = id;
        }
    }
}
