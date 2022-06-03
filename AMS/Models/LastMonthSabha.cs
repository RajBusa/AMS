using System.ComponentModel.DataAnnotations;

namespace AMS.Models
{
    public class LastMonthSabha
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DOB { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Education { get; set; }
        public string? Email { get; set; }
        public int MandalId { get; set; }
        public int SamparkId { get; set; }
        public int count{ get; set; }
    }
}
