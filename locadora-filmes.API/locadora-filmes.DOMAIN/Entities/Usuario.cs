using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace locadora_filmes.DOMAIN.Entities {

    public enum UsuarioCargoEnm{
        CLIENTE = 1,
        ADMINISTRADOR = 2 
    }

    public class Usuario : Base{

        public String Auditoria { get; private set; }

        [Required(ErrorMessage = "É nessário escolher o cargo do usuário!")]
        public UsuarioCargoEnm Cargo { get; private set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório!")]
        [MaxLength(30, ErrorMessage = "Máximo de 30 caracteres")]
        [MinLength(3, ErrorMessage = "Minimo de 3 caracteres ")]
        public String Nome { get; private set; }

        [Required(ErrorMessage = "O email é obrigatório!")]
        [MaxLength(25, ErrorMessage = "Máximo de 25 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public String Email { get; private set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres")]
        [MinLength(8, ErrorMessage = "Minimo de 8 caracteres ")]
        public String Senha { get; private set; }

        public virtual ICollection<Voto> Voto { get; private set; }

        public Usuario() : base() {

        }
        public Usuario(dynamic obj) : base() {
            this.Id = obj.Id;
            this.Auditoria = obj.Auditoria;
            this.Status = obj.Status;
            this.Cargo = obj.Cargo;
            this.Nome = obj.Nome;
            this.Email = obj.Email;
            this.Senha = obj.Senha;

        }

        public void SetStatus(String status) {
            this.Status = status;
        }

        public void SetAuditoria(String auditoria) {
            this.Auditoria = auditoria;
        }

        public void EncryptPassword() {
            this.Senha = BCrypt.Net.BCrypt.HashPassword(this.Senha);
        }

        public Boolean HasPermission() {
            return this.Cargo == UsuarioCargoEnm.ADMINISTRADOR ?  true : false;
        }
    }

}
