using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace bookDemo.Controllers
{
    [Route("api/books/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }
        [HttpGet("{id:int}")]//Ayırt edebilmek yani endpoint'leri değiştirebilmek için imza olarak id kısmını ekledik.
        public IActionResult GetOneBook([FromRoute(Name ="id")]int id)//FromRoute, FromBody,FromHeader=Binding için bu ifadeler önemlidir.
        {
            var book = ApplicationContext.Books.Where(b=>b.ID.Equals(id)).SingleOrDefault();//LINQ= dile entegre sorgu anlamındadır.
            if(book is null)
                return NotFound();//404
            return Ok(book);
        }
        //Burada iki tane Get Metodu var ancak bunları birbirinden ayırt edebilen yok.
        [HttpPost] //201 Created-400 Bad Request
        public IActionResult CreateOneBook([FromBody]Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest();//400
                ApplicationContext.Books.Add(book);
                return StatusCode(201, book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id:int}")]//200 Success-204 No Content-409 Conflict
        public IActionResult UpdateOneBook([FromRoute(Name ="id")] int id, [FromBody] Book book)
        {
            //check book?
            var entity = ApplicationContext.Books.Find(b => b.ID.Equals(id));
            if(entity is null)
            {
                //Var ise logger ekleyebiliriz.
                return NotFound(); //404
            }
            //check id
            if(id!=book.ID)
            {
                return BadRequest(); //400
            }
            ApplicationContext.Books.Remove(entity);
            book.ID = entity.ID;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }
        [HttpDelete] /* ./books=tüm kitapları siler  /books/{id} 204 NoContent, 404 NotFound */
        public IActionResult DeleteAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent();//204
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute]int id)
        {
            var entity=ApplicationContext.Books.Find(b=>b.ID.Equals(id));
            if(entity is null)
                return NotFound(new
                {
                    statusCode=404,
                    message=$"Book with id:{id} could not found"
                });
            ApplicationContext.Books.Remove(entity);
            return NoContent();
        }
        [HttpPatch("{id:int}")]/* /books/{id} 200Success 204NoContent 415Unsupportedmediatypes 400BadRequest[malformed] 409 Conflict*/
        public IActionResult PartialUpdatedOneBook([FromRoute(Name ="id")]int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            //check entity
            var entity = ApplicationContext.Books.Find(b=>b.ID.Equals(id));
            if (entity is null)
            { 
                return NotFound(); 
            }
            bookPatch.ApplyTo(entity);
            return NoContent();
        }
    }
}