namespace OptimalSchedule
{
    public class RouteOptimizer
    {
        public List<Sight> FindOptimalRoute(IEnumerable<Sight> sights, double maxTime)
        {
            var sightList = sights.ToList();
            int n = sightList.Count;
            int maxTimeInMinutes = (int)(maxTime * 60); // Переводим время в минуты

            // Массив для динамического программирования
            int[,] res = new int[n + 1, maxTimeInMinutes + 1];

            // Заполняем таблицу res
            for (int i = 1; i <= n; i++)
            {
                for (int t = 0; t <= maxTimeInMinutes; t++)
                {
                    // Не берем текущую достопримечательность
                    res[i, t] = res[i - 1, t];

                    int timeInMinutes = (int)(sightList[i - 1].Time * 60);

                    if (t >= timeInMinutes) // Если можем взять достопримечательность
                    {
                        res[i, t] = Math.Max(res[i, t], res[i - 1, t - timeInMinutes] + sightList[i - 1].Importance);
                    }
                }
            }

            // Восстанавливаем маршрут
            var optimalRoute = new List<Sight>();
            int remainingTime = maxTimeInMinutes;

            for (int i = n; i > 0 && remainingTime > 0; i--)
            {
                int timeInMinutes = (int)(sightList[i - 1].Time * 60);
                if (remainingTime >= timeInMinutes &&
                    res[i, remainingTime] == res[i - 1, remainingTime - timeInMinutes] + sightList[i - 1].Importance)
                {
                    optimalRoute.Add(sightList[i - 1]);
                    remainingTime -= timeInMinutes;
                }
            }

            return optimalRoute;
        }


    }
}
