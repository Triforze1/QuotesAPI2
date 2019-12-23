using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesAPI2.Data;
using QuotesAPI2.Models;

namespace QuotesAPI2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {

        private readonly QuotesDbContext _quotesDbContext;


        public QuotesController(QuotesDbContext quotesDbContext)
        {
            _quotesDbContext = quotesDbContext;
        }


        // GET: api/Quotes
        [HttpGet]
        public IActionResult Get()
        {

           return Ok(_quotesDbContext.Quotes);
        }


        // GET: api/Quotes/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("No record was found...");
            }
            else
            {
                return Ok(quote);
            }
            

        }


        // POST: api/Quotes
        [HttpPost]
        public IActionResult Post([FromBody] Quote quote)
        {
            _quotesDbContext.Quotes.Add(quote);
            _quotesDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);

        }


        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Quote quote)
        {
            var information = _quotesDbContext.Quotes.Find(id);

            if (information == null)
            {
                return NotFound("No record found against this Id...");
            }
            else
            {
                information.Title = quote.Title;
                information.Author = quote.Author;
                information.Description = quote.Description;
                information.Title = quote.Title;
                information.Type = quote.Type;
                information.createdAt = quote.createdAt;
                _quotesDbContext.SaveChanges();
                return Ok("Records updated successfully...");
            }
            
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quote = _quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return NotFound("The quote was not found against this id...");
            }
            else
            {
                _quotesDbContext.Quotes.Remove(quote);
                _quotesDbContext.SaveChanges();
                return Ok("The quote has been deleted successfully");
            }
            
        }
    }
}
