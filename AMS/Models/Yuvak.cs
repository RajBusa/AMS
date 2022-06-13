using AMS.web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class Yuvak
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }
        public DateTime DOB { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        [StringLength(15)]
        public string? Mobile { get; set; }

        [StringLength(30)]
        public string? Education { get; set; }

        [StringLength(30)]
        public string? Email { get; set; }

        [ForeignKey("Mandal")]
        public int MandalId { get; set; }
        public Mandal? Mandal { get; set; }


        [ForeignKey("Karyakar")]
        public int SamparkId { get; set; }
        public Karyakar? Karyakar { get; set; }

        public bool isSamparkKaryakar { get; set; }
        public bool isAttendanceTaken { get; set; }
    }
}
