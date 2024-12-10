using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class Bmicalculator
    {
        [Key]
        public int Id { get; set; }
        public double Weight { get; set; }  
        public double Height { get; set; }

        [ForeignKey("planishraneid")]
        public int planishraneid { get; set; }
        public PlanIshrane planIshrane { get; set; }
    }
}
