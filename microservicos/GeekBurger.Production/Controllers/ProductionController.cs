using GeekBurger.Production.Model;
using Microsoft.AspNetCore.Mvc;
using System;
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
            var guid = new Guid("8048e9ec-80fe-4bad-bc2a-e4f4a75c834e");
           return new Productions
            {
                ProductionId = guid,
                Restrictions = new List<string>(){ "soy","dairy","gluten","peanut" },
                On = false
            };
        }
    }
}