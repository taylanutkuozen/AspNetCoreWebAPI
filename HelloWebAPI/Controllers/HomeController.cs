using HelloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
namespace HelloWebAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        //[HttpGet]
        //public string GetMessage()
        //{
        //    return "Hello ASP.NET Core Web API";
        //}
        //[HttpGet]
        //public ResponseModel GetMessages()
        //{
        //    return new ResponseModel() { HttpStatus=200, Message="Sonuç Başarılı" };
        //}
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel() { HttpStatus = 200, Message = "Sonuç Başarılı" };
            return Ok(result);
        }
    }
}