namespace TraversalApp.MVC.CQRS.Results.GuideResults
{
    public class GetAllGuideQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
    }
}
