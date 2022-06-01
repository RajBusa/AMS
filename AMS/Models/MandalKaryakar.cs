using AMS.web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class MandalKaryakar
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Mandal")]
        public int MandalId { get; set; }
        public Mandal? Mandal { get; set; }


        [ForeignKey("Karyakar")]
        public int KaryakarId { get; set; }
        public Karyakar? Karyakar { get; set; }
    }
}
