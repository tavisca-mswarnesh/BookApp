using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SampleHelloWorld.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        // GET: api/Home
        private readonly BookServices _bookServices;
        public HomeController(BookServices bookServices)
        {
            //bookList.Add(new Book { id = 1, Name = "Harry Potter", price = 300, author = "J K Rowling", NoOfPages = 200 });
            //bookList.Add(new Book { id = 2, Name = "Let Us C", price = 400, author = "Yeswant Kanitkar", NoOfPages = 600 });
            //bookList.Add(new Book { id = 3, Name = "The Alchamist", price = 210, author = "paulo", NoOfPages = 250 });
            _bookServices = bookServices;

        }
        [HttpGet]
        public IActionResult GetBook()
        {

            return  Ok(_bookServices.GetBook());
        }

        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            
            return Ok(_bookServices.Get(id));
        }

        // POST: api/Home
        [HttpPost]
        public IActionResult Post(Book book)
        {
            
            return Ok(_bookServices.Post(book));
        }

        // PUT: api/Home/5
        [HttpPut]
        public IActionResult Put(Book book)
        {
            
            return Ok(_bookServices.Put(book));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_bookServices.Delete(id));
        }
    }
}
