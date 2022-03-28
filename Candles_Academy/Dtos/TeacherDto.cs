using Microsoft.AspNetCore.Http;

namespace Candles_Academy.Dtos
{
    public class TeacherDto
    {
        public string Name { get; set; }

        public IFormFile? Poster { get; set; }

        public int CourseId { get; set; }

        public int Rate { get; set; }

    }
}
