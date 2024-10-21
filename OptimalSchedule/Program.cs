using OptimalSchedule.Interfaces;

namespace OptimalSchedule
{
    public class Program
    {
        static void Main()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Data\sights.csv");


            ISightDataProvider dataProvider = new CsvSightsDataProvider(filePath);
            var sights = dataProvider.GetSights();

            if (!sights.Any())
            {
                Console.WriteLine("Не удалось загрузить достопримечательности.");
                return;
            }

            const double AVAILABLE_TIME = 32; // Ограничение по времени в часах

            var optimizer = new RouteOptimizer();
            var optimalRoute = optimizer.FindOptimalRoute(sights, AVAILABLE_TIME);

            Console.WriteLine("Оптимальный маршрут:");
            foreach (var sight in optimalRoute)
            {
                Console.WriteLine(sight);
            }
        }
    }
}
