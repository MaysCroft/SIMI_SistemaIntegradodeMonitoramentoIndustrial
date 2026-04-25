using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shared
{
    public class SensorData
    {
        public int Id { get; set; }
        public double Temperatura { get; set; }
        public double Pressao { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
