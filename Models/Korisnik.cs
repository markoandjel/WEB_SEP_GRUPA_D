using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Korisnik
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(60)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(60)]
        public string Prezime { get; set; }
        public Prodavnica Prodavnica { get; set; }
        public List<Kuca> ListaKuca { get; set; }
    }
}