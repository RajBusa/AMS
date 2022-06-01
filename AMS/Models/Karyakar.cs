using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.web.Models
{
    public class Karyakar
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }

        public DateTime DOB { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        [StringLength(15)]
        public string? MobileNo { get; set; }


        [StringLength(30)]
        public string? Education { get; set; }

        [ForeignKey("KarayakarRole")]
        public int RoleId { get; set; } 
        public KaryakarRole? KarayakarRole { get; set; }

        [StringLength(30)]
        public string? Email { get; set; }
        public string? Password { get; set; }

        public bool isActivated { get; set; }

        [ForeignKey("KshetraId")]
        public int KshetraId { get; set; }
        public Kshetra? Kshetra { get; set; }

        public int KarayakarNo { get; set; }
    }
}
