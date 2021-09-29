﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Entities {
    public class Filmes : Base {

        public String Diretor { get; set; }
        public String Status { get; set; }
        public String Titulo { get; set; }
        public List<String> Genero { get; set; }
        public List<String> Atores { get; set; }
        public DateTime Lancamento { get; set; }
        public Int16 Pontuacao { get; set; }
        public Int32 QtdVotos { get; set; }
        public String Sinopse { get; set; }
    }
}
