namespace TraversalApp.MVC.CQRS.Queries.DestinationQueries
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int destId)
        {
            DestId = destId;
        }

        public int DestId { get; set; }

    }
}
