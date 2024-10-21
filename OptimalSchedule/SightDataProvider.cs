using OptimalSchedule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalSchedule
{
    public class CsvSightsDataProvider : ISightDataProvider
    {
        private readonly string _filePath;

        public CsvSightsDataProvider(string filePath)
        {
            _filePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
        }

        public IEnumerable<Sight> GetSights()
        {
            var sightList = new List<Sight>();

            try
            {
                foreach (var line in File.ReadLines(_filePath))
                {
                    var parts = line.Split(';');

                    if (parts.Length != 3)
                    {
                        Console.WriteLine($"Некорректная строка: {line}");
                        continue;
                    }

                    string name = parts[0];

                    string timeString = parts[1].Replace("ч", "");

                    if (!double.TryParse(timeString, out double time))
                    {
                        Console.WriteLine($"Некорректное значение времени: {parts[1]}");
                        continue;
                    }

                    if (!int.TryParse(parts[2], out int importance))
                    {
                        Console.WriteLine($"Некорректное значение важности: {parts[2]}");
                        continue;
                    }

                    sightList.Add(new Sight(name, time, importance));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return sightList;
        }
    }
}
