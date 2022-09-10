using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Prodavnica
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        [DefaultValue(0)]
        public int Prihod { get; set; }
        public List<Spoj> ListaSpojeva { get; set; }
    }
}