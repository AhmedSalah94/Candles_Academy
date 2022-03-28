namespace Candles_Academy.Dtos
{

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class PostCourseDto
    {

        [MaxLength(100)]
        public string Name { get; set; }

    }
}
