using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using TraversalApp.SignalRForMsSql.DAL;
using TraversalApp.SignalRForMsSql.Hubs;

namespace TraversalApp.SignalRForMsSql.Models
{
    public class VisitorService
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<VisitorHub> _hubContext;

        public VisitorService(IHubContext<VisitorHub> hubContext, AppDbContext context)
        {
            _hubContext = hubContext;
            _context = context;
        }
        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", GetVisitorChartList());
        }

        public List<VisitorChart> GetVisitorChartList()
        {
            List<VisitorChart> visitorCharts = new List<VisitorChart>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select tarih, [1],[2],[3],[4],[5] from (select[City], CityVisitorCount, Cast([VisitDate] as Date) as tarih from Visitors) as visitTable Pivot (Sum (CityVisitorCount) For City in([1], [2],[3],[4],[5])) as pivottable order by tarih asc";

                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChart visitorChart = new VisitorChart();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x =>
                        {
                            visitorChart.Counts.Add(reader.GetInt32(x));
                        });
                        visitorCharts.Add(visitorChart);
                    }
                }
                _context.Database.CloseConnection();
                return visitorCharts;
            }
        }
    }
}
