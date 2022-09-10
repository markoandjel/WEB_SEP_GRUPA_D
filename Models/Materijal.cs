using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Materijal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Naziv { get; set; }

        [Required]
        [MaxLength(40)]
        public string Boja { get; set; }

        [Required]
        [MaxLength(10)]
        public string Tip { get; set; } //{kuca, fasada, krov, stolarija}
        public List<Spoj> Spojevi { get; set; }

    }
}