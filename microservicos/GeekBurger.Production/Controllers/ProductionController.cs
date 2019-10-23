using GeekBurger.Production.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeekBurger.Production.Controllers
{
    [ApiController]
    [Route("api/production")]
    public class ProductionController : Controller
    {
        [HttpGet("areas")]
        public Productions GetAreas ()
        {
           return new Productions
            {
                On = true
            };
        }
    }
}