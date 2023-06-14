namespace TraversalApp.SignalR.DAL
{
    public enum ECity
    {
        Kutahya = 1,
        Istanbul = 2,
        Ankara = 3,
        Eskisehir = 4,
        Izmir = 5

    }
    public class Visitor
    {
        public int Id { get; set; }
        public ECity City { get; set; }
        public int CityVisitorCount { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
