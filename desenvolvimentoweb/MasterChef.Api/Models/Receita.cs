using System;
using System.Collections.Generic;

namespace MasterChef.Api.Models
{
    public class Receita
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ModoDePreparo { get; set; }
        public byte[] Foto { get; set; }
        public string Tag { get; set; }
        public string DataDeCadastro { get; set; }
    }
}
