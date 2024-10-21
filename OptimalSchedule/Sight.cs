using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalSchedule
{
    public class Sight
    {
        public string Name { get; }
        public double Time { get; }
        public int Importance { get; }

        public Sight(string name, double time, int importance)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Time = time;
            Importance = importance;
        }

        public override string ToString()
        {
            return $"{Name} Время: {Time}ч, Важность: {Importance}";
        }
    }
}
