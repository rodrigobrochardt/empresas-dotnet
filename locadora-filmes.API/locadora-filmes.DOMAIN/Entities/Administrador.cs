using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Entities {
    public class Administrador : Base {

        public String Auditoria { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String Status { get; set; }


        public Administrador() : base() {

        }
        public Administrador(dynamic obj) : base() {
            this.Id = obj.Id;
            this.Auditoria = obj.Auditoria;
            this.Status = obj.Status;
            this.Nome = obj.Nome;
            this.Email = obj.Email;
            this.Senha = obj.Senha;
        
        }


        public void SetStatus(String status) {
            this.Status = status;
        }

    }
}
