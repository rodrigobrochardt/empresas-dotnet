using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace locadora_filmes.DOMAIN.Entities {
    public class Filme : Base {

        public String Auditoria { get; private set; }

        [Required(ErrorMessage = "O nome do diretor é obrigatório!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        public String Diretor { get; private set; }

        [Required(ErrorMessage = "O titulo do filme é obrigatório!")]
        [MaxLength(50, ErrorMessage = "Máximo de 50 caracteres")]
        [MinLength(3, ErrorMessage = "Minimo de 3 caracteres ")]
        public String Titulo { get; private set; }

        [Required(ErrorMessage = "É obrigatório escolher um gênero para o filme!")]
        public String Genero { get; private set; }

        public String Atores { get; private set; }

        public DateTime Lancamento { get; private set; }

        public Decimal Pontuacao { get; private set; }

        public int QtdVotos { get; private set; }

        [MaxLength(256, ErrorMessage = "Máximo de 256 caracteres")]
        public String Sinopse { get; private set; }

        public virtual ICollection<Voto> Voto { get; private set; }


        public Filme() : base() {

        }
        public Filme(dynamic obj) : base() {
            this.Id = obj.Id;
            this.Auditoria = obj.Auditoria;
            this.Diretor = obj.Diretor;
            this.Status = obj.Status;
            this.Titulo = obj.Titulo;
            this.Genero = string.Join(",", obj.Genero);
            this.Atores = string.Join(",", obj.Atores);
            this.Lancamento = obj.Lancamento.Date;
            this.Pontuacao = obj.Pontuacao;
            this.QtdVotos = obj.QtdVotos;
            this.Sinopse = obj.Sinopse;

        }

        public void SetStatus(String status) {
            this.Status = status;
        }

        public void SetAuditoria(String auditoria) {
            this.Auditoria = auditoria;
        }
    }
}
