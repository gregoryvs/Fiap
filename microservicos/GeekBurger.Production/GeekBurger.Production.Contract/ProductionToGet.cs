using System;
using System.Collections.Generic;

namespace GeekBurger.Production.Contract
{
    public class ProductionToGet
    {
        public Guid ProductionId { get; set; }
        public List<string> Restrictions { get; set; }
        public bool On { get; set; }
    }
}
