using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficialLab3.Models
{
    [Table("Staff")]
    public partial class Staff
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string Name { get; set; } = null!;

        public string Title { get; set; } = null!;
        public int Salary { get; set; }
    }
}
