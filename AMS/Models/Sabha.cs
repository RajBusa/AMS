using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AMS.Models
{
    public class Sabha
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Mandal")]
        public int MandalId { get; set; }
        public Mandal? Mandal { get; set; }

        public DateTime Date { get; set; }
    }
}
