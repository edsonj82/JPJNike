using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPJNike.API.Models
{
    public class Corrida
    {
        public int Id { get; set; }

        public int TempoMinutos { get; set; }

        public int TempoSegundos { get; set; }

        public double Distancia { get; set; }

        public DateTime Data { get; set; }
    }
}
