using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AdoCao.Models
{
    [Table("Cachorros")]
    public class Cachorro
    {
        [PrimaryKey]
        public Guid IdDog { get; set; }
        [MaxLength(100)]
        public Guid IdDono { get; set; }
        [MaxLength(100)]
        public string NomeDog { get; set; }
        [MaxLength(100)]
        public string SexoDog { get; set; }
        [MaxLength(100)]
        public string RacaDog { get; set; }
        [MaxLength(100)]
        public string RuaDog { get; set; }
        [MaxLength(100)]
        public string NumeroDog { get; set; }
        [MaxLength(100)]
        public string ComplementoDog { get; set; }
        [MaxLength(100)]
        public string CepDog { get; set; }
        [MaxLength(100)]
        public string CidadeDog { get; set; }
        [MaxLength(5000)]
        public string DescricaoDog { get; set; }
        [MaxLength(100)]
        public string KeyDog { get; set; }

        public byte[] ImagemDog { get; set; }

        public Cachorro()
        {
            IdDog = Guid.NewGuid(); 
        }
    }
}
