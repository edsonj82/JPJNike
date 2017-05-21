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
                    Data = DateTime.Now.AddMonths(-1),
                    TempoMinutos = 120,
                    TempoSegundos = 7200,
                    Distancia = 1
                },
                new Corrida
                {
                    Id = 3,
                    Data = DateTime.Now.AddMonths(-1),
                    TempoMinutos = 10,
                    TempoSegundos = 600,
                    Distancia = 1
                },
                new Corrida
                {
                    Id = 4,
                    Data = DateTime.Now.AddMonths(-1),
                    TempoMinutos = 20,
                    TempoSegundos = 1200,
                    Distancia = 1
                },
                new Corrida
                {
                    Id = 5,
                    Data = DateTime.Now.AddMonths(-1),
                    TempoMinutos = 120,
                    TempoSegundos = 7200,
                    Distancia = 1
                },
                new Corrida
                {
                    Id = 6,
                    Data = DateTime.Now,
                    TempoMinutos = 40,
                    TempoSegundos = 2400,
                    Distancia = 1
                },
            };
        }

        // GET: api/corrida
        [HttpGet]
        public List<Corrida> GetAll()
        {
            return _corridas;
        }

        [HttpGet("month/{month}")]
        public IActionResult GetAllLastMonth(int? month)
        {
            if (!month.HasValue)
            {
                return BadRequest();
            }
            return Ok(_corridas.FindAll(c => c.Data.Month == month.Value));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Corrida corrida = _corridas.Find(c => c.Id == id);
            if (corrida == null)
            {
                //return new NotFoundResult();
                return NotFound();
            }
            return Ok(corrida);
        }

        [HttpPost]
        public void Create([FromBody]Corrida dados)
        {
            _corridas.Add(dados);
        }

        [HttpPut("{id}")]
        public void Update(int? id, [FromBody] Corrida dados)
        {
            foreach (Corrida corrida in _corridas)
            {
                if (corrida.Id == id.Value)
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
