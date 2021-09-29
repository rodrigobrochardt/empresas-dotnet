using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Entities {
    public class UsuarioModel : BaseModel {

        public String Auditoria { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String Status { get; set; }


    }

}
