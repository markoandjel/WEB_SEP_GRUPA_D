using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Spoj
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        public int CenaMaterijala { get; set; }
        public Prodavnica Prodavnica { get; set; }
        public Materijal Materijal { get; set; }
    }
}