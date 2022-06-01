using AMS.web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class KshetraNirdeshak
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Kshetra")]
        public int KshetraId { get; set; }
        public Kshetra? Kshetra { get; set; }


        [ForeignKey("Karyakar")]
        public int NirdeshakId { get; set; }
        public Karyakar? Karyakar { get; set; }
    }
}
