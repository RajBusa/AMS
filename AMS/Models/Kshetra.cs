using System.ComponentModel.DataAnnotations;

namespace AMS.web.Models
{
    public class Kshetra
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

    }
}