using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace locadora_filmes.DOMAIN.Entities {
    public abstract class Base {
        public Int16 Id { get; set; }



        private List<ValidationResult> _validationsErros;

        public bool IsValid() {
            this._validationsErros = new List<ValidationResult>();
            var context = new ValidationContext(this);
            return Validator.TryValidateObject(this, context, _validationsErros, true);
        }

        public List<ValidationResult> GetValidationResults() {
            return _validationsErros;
        }
    }
}
