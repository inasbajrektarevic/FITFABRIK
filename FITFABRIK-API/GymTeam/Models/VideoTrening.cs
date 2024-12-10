using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymTeam.Models
{
    public class VideoTrening
    {
        [Key]
        public int id { get; set; }
        public string naslov { get; set; }

        public string ukupnoTrajanje { get; set; }
        public string opis { get; set; }

        [ForeignKey("privatnitrenerid")]
        public int privatnitrenerid { get; set; }
        public PrivatniTrener privatniTrener { get; set; }

    }
}
