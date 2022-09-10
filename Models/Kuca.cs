using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Kuca
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Prodavnica Prodavnica { get; set; }

        [Required]
        public Korisnik Korisnik { get; set; }

        [Required]
        public DateTime DatumPorudzbine { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int Cena { get; set; }

    }
}