using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalSchedule.Interfaces
{
    public interface ISightDataProvider
    {
        IEnumerable<Sight> GetSights();
    }
}
