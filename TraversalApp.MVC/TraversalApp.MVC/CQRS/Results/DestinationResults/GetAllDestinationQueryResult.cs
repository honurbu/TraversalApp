namespace TraversalApp.MVC.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        public int Id { get; set; }
        public string Cities { get; set; }
        public string DayNights { get; set; }
        public string Prices { get; set; }
        public int Capacities { get; set; }

    }
}
