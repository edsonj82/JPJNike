using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JPJNike.API.Data;
using JPJNike.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JPJNike.API.Controllers
{
    [Route("api/[controller]")]
    public class ExercicioController : Controller
    {
        // GET: api/values
        [HttpGet]
        public List<Exercicio> Get()
        {
            using (Database db = new Database())
            {
                List<Exercicio> exercColl = db.Exercicio.ToList();
                return exercColl;
            }
        }

        // GET: api/values
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            using (Database db = new Database())
            {
                Exercicio exercicio = db.Exercicio.Find(id);

                if (exercicio == null)
                {
                    return NotFound();
                }

                return Ok(exercicio);
            }
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]Exercicio value)
        {
            using (Database db = new Database())
            {
                db.Exercicio.Add(value);
                db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (Database db = new Database())
            {
                Exercicio exercicioRemove = db.Exercicio.Find(id);
                if (exercicioRemove == null)
                {
                    return NotFound();
                }

                db.Exercicio.Remove(exercicioRemove);
                db.SaveChanges();
                return Ok();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Exercicio value)
        {
            using (Database db = new Database())
            {
                db.Exercicio.Update(value);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
