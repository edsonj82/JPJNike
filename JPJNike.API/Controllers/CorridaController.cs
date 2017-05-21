using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JPJNike.API.Models;
using JPJNike.API.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JPJNike.API.Controllers
{
    [Route("api/[controller]")]
    public class CorridaController : Controller
    {
        private static List<Corrida> _corridas;
        private static DatasourceXML datasource = new DatasourceXML();

        static CorridaController()
        {
            _corridas = datasource.Corridas;
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

        [HttpGet("lastrunning")]
        public IActionResult GetLastRunning()
        {
            Corrida comparador = _corridas[0];
            for (int i = 1; i < _corridas.Count; i++)
            {
                if (comparador.Data < _corridas[i].Data)
                {
                    comparador = _corridas[i];
                }
            }
            return Ok(comparador);
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
