using System;
using System.ComponentModel.DataAnnotations;

namespace locadora_filmes.DOMAIN.Entities {

   
    public class Voto : Base{

        public String Auditoria { get; private set; }

        [Required(ErrorMessage = "O Id do filme é obrigatório!")]

        public int FilmeId { get; private set; }

        [Required(ErrorMessage = "O Id do usuário é obrigatório!")]
        public int UsuarioId { get; private set; }

        [Required(ErrorMessage = "A nota é obrigatório!")]
        public decimal Nota { get; private set; }

        public virtual Usuario Usuario { get; private set; }

        public virtual Filme Filme { get; private set; }

        public Voto() : base() {

        }
        public Voto(dynamic obj) : base() {
            this.Id = obj.Id;
            this.Auditoria = obj.Auditoria;
            this.Status = obj.Status;
            this.FilmeId = obj.Filme.Id;
            this.UsuarioId = obj.Usuario.Id;
            this.Nota = obj.Nota;

        }

        public void SetStatus(String status) {
            this.Status = status;
        }

        public void SetAuditoria(String auditoria) {
            this.Auditoria = auditoria;
        }

    }

}
