using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class LastMonthSabha
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

        public int MandalId { get; set; }


        public int SamparkId { get; set; }

        public int count{ get; set; }
    }
}
