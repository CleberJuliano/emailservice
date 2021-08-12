using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos {
    public class EmailDto {
        public string EmailDeDestino { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string NomeDaAplicacao { get; set; }
    }
}
