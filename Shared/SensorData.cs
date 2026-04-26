using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shared
{
    /// <summary>
    /// SensorData - Classe que representa os dados coletados pelos sensores.
    /// Ela contém propriedades para armazenar a temperatura, pressão e o timestamp
    /// (data e hora) da leitura do sensor.
    /// </summary>
    public class SensorData
    {
        public int Id { get; set; }
        public double Temperatura { get; set; }
        public double Pressao { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
