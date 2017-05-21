using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPJNike.API.Models
{
    public class Exercicio
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Quantidade de exercicio
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Quantidade de series
        /// </summary>
        public int Series { get; set; }
    }
}
