using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SQLite;

namespace AdoCao.Models
{
    [Table("Cachorros")]
    public class Cachorro
    {
        [PrimaryKey]
        public Guid IdDog { get; set; }
        [StringLength(100)]
        public Guid IdDono { get; set; }
        [Range(4, 20, ErrorMessage = "Teste")]
        public string NomeDog { get; set; }
        public string SexoDog { get; set; }
        [StringLength(100)]
        public string RacaDog { get; set; }
        [StringLength(100)]
        public string RuaDog { get; set; }
        [StringLength(100)]
        public string NumeroDog { get; set; }
        [StringLength(100)]
        public string ComplementoDog { get; set; }
        [StringLength(100)]
        public string CepDog { get; set; }
        [StringLength(100)]
        public string CidadeDog { get; set; }
        [StringLength(5000)]
        public string DescricaoDog { get; set; }
        [StringLength(100)]
        public string KeyDog { get; set; }

        public byte[] ImagemDog { get; set; }

        public Cachorro()
        {
            IdDog = Guid.NewGuid(); 
        }
    }
}
