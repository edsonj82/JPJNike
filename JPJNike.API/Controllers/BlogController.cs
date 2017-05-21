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
    public class BlogController : Controller
    {
        private Database _db;

        public BlogController(Database db)
        {
            _db = db;
        }


        // GET: api/values
        [HttpGet]
        public IEnumerable<BlogPost> Get()
        {
            List<BlogPost> posts = _db.BlogPosts.ToList();
            return posts;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public BlogPost Get(int id)
        {
            BlogPost post = _db.BlogPosts.Find(id);
            return post;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]BlogPost value)
        {
            _db.BlogPosts.Add(value);
            _db.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]BlogPost value)
        {
            _db.BlogPosts.Update(value);
            _db.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            BlogPost postRemove = _db.BlogPosts.Find(id);
            if (postRemove != null)
            {
                _db.BlogPosts.Remove(postRemove);
                _db.SaveChanges();
            }
        }
    }
}
