namespace TraversalApp.MVC.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int Id { get; set; }
        public string Cities { get; set; }
        public string DayNights { get; set; }
        public string Prices { get; set; }
    }
}
