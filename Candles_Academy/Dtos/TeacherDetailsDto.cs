using Microsoft.AspNetCore.Http;

namespace Candles_Academy.Dtos
{
    public class TeacherDetailsDto
    {
        public string Name { get; set; }

        public byte[] Poster { get; set; }

        public int CourseId { get; set; }

        public int Rate { get; set; }

    }
}
