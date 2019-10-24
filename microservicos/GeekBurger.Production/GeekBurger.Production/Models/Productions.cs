using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GeekBurger.Production.Model
{
    public class Productions
    {
        [Key]
        public Guid ProductionId { get; set; }
        public List<string> Restrictions { get; set; }
        public bool On { get; set; }
    }
}