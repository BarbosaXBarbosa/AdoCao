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
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Senha { get; set; }

        //Firebase
        public string Key { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
