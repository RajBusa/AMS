using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMS.Models
{
    public class SabhaAttendance
    {

        [Key]
        public int Id { get; set; } 

        [ForeignKey("Yuvak")]
        public int YuvakId { get; set; }
        public Yuvak? Yuvak { get; set; }


        [ForeignKey("Sabha")]
        public int SabhaId { get; set; }
        public Sabha? Sabha { get; set; }

        public DateTime Attendance { get; set; }
    }
}
