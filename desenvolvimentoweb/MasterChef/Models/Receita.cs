using System.Collections.Generic;
using System.IO;

namespace MasterChef.Models
{
    public class Receita
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public string ModoDePreparo { get; set; }
        public FileStream Foto { get; set; }
        public string Tag { get; set; }

    }
}