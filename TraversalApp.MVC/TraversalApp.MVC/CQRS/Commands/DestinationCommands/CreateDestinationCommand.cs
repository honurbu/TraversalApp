namespace TraversalApp.MVC.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public string Price { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }

    }
}
