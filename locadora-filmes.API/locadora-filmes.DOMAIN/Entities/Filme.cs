using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace locadora_filmes.DOMAIN.Entities {
    public class Filme : Base {

        public String Auditoria { get; set; }
        public String Diretor { get; set; }
        public String Status { get; set; }
        public String Titulo { get; set; }
        public List<String> Genero { get; set; }
        public List<String> Atores { get; set; }
        public DateTime Lancamento { get; set; }
        public Int16 Pontuacao { get; set; }
        public Int32 QtdVotos { get; set; }
        public String Sinopse { get; set; }


        public Filme() : base() {

        }
        public Filme(dynamic obj) : base() {
            this.Id = obj.Id;
            this.Auditoria = obj.Auditoria;
            this.Diretor = obj.Diretor;
            this.Status = obj.Status;
            this.Titulo = obj.Titulo;
            this.Genero = obj.Genero;
            this.Atores = obj.Atores;
            this.Lancamento = obj.Lancamento;
            this.Pontuacao = obj.Pontuacao;
            this.QtdVotos = obj.QtdVotos;
            this.Sinopse = obj.Sinopse;

        }

        public void SetStatus(String status) {
            this.Status = status;
        }
    }
}
