using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class PlanIshrane
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public int ukupanBrojKalorija { get; set; }

        [ForeignKey("produktid")]
        public int produktid { get; set; }
        public Produkt produkt { get; set; }
    }
}
