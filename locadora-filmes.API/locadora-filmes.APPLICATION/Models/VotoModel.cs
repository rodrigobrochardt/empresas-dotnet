using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Entities {
    public class VotoModel : BaseModel {

        public String Auditoria { get; set; }
        public FilmeModel Filme { get; set; }
        public UsuarioModel Usuario { get; set; }
        public String Status { get; set; }
        public decimal Nota { get; set; }


    }

}
