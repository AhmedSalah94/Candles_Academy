using System.ComponentModel.DataAnnotations.Schema;

namespace Candles_Academy.Models
{
    public class Teacher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rate { get; set; }

        public byte[] Poster { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
