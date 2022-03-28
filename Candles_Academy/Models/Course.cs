using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candles_Academy.Models
{
    public class Course
    {
        public int Id { get; set; } 

        [MaxLength(100)]
        public string Name { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}