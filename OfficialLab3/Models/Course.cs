using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficialLab3.Models
{
    [Table("Course")]
    public partial class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string? Name { get; set; }
        public int TeacherId { get; set; }

        [ForeignKey(nameof(TeacherId))]
        [InverseProperty("Courses")]
        public virtual Teacher Teacher { get; set; } = null!;

        [ForeignKey("CourseId")]
        [InverseProperty(nameof(Student.Courses))]
        public virtual ICollection<Student> Students { get; set; }
    }
}
