using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AdoCao.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        //Propriedades
        [PrimaryKey]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string CPF { get; set; }
        [MaxLength(100)]
        public string Cidade { get; set; }
        [MaxLength(100)]
        public string Bairro { get; set; }
        [MaxLength(100)]
        public string Rua { get; set; }
        [MaxLength(100)]
        public string Numero { get; set; }
        [MaxLength(8)]
        public string Complemento { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Senha { get; set; }
        [MaxLength(15)]
        public string Confirmasenha { get; set; }

        //Firebase
        public string Key { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
