using System;
using System.Collections.Generic;

namespace GeekBurger.Production.Contract
{
    public class Production
    {
        public Guid StoreId { get; set; }
        public int ProductionId { get; set; }
        public List<string> Restrictions { get; set; }
        public bool On { get; set; }
    }
}
