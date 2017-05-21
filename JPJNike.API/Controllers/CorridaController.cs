using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JPJNike.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JPJNike.API.Controllers
{
    [Route("api/[controller]")]
    public class CorridaController : Controller
    {
        private static List<Corrida> _corridas;

        static CorridaController()
        {
            _corridas = new List<Corrida>()
            {
                new Corrida
                {
                    Id = 1,
                    Data = DateTime.Now.AddDays(-2),
                    TempoMinutos = 60,
                    TempoSegundos = 3600,
                    Distancia = 0.5
                },
                new Corrida
                {
                    Id = 2,
                    Data = DateTime.Now.AddDays(-1),
                    TempoMinutos = 120,
                    TempoSegundos = 7200,
                    Distancia = 1
                },
            };
        }

        // GET: api/corrida
        [HttpGet]
        public IEnumerable<Corrida> GetAll()
        {
            return _corridas;
        }

        [HttpGet("{id}")]
        public Corrida Get(int id)
        {
            Corrida corrida = _corridas.Find(c => c.Id == id);
            return corrida;
        }

        [HttpPost]
        public void Create([FromBody]Corrida dados)
        {
            _corridas.Add(dados);            
        }

        [HttpPut("{id}")]
        public void Update(int? id,[FromBody] Corrida dados)
        {
            foreach (Corrida corrida in _corridas)
            {
                if(corrida.Id == id.Value)
                {
                    corrida.TempoMinutos = dados.TempoMinutos;
                    corrida.TempoSegundos = dados.TempoSegundos;
                    corrida.Distancia = dados.Distancia;
                    corrida.Data = dados.Data;
                    break;
                }
            }                    
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _corridas.RemoveAll(c => c.Id == id);
        }

    }
}
