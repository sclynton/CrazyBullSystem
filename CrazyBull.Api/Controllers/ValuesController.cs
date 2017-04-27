using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrazyBull.Data.Interfaces;
using CrazyBull.Models;

namespace CrazyBull.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public ValuesController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository; 
        }
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookRepository.GetAll();
            return new JsonResult(books).StatusCode = 0;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
