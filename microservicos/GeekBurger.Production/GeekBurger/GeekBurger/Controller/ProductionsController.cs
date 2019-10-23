using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekBurger.Production.Contract;

namespace GeekBurger.Controllers
{
    [ApiController]
    public class ProductionsController : Controller
    {
        
        [Route("api/productions/areas")]
        [HttpGet]
        public IActionResult GetProduction()
        {
            Production production = new GeekBurger.Production();
            return Ok();
        }
    }
}