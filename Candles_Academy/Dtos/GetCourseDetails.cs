
namespace Candles_Academy.Dtos
{
    using System.Collections.Generic;

    public class GetCourseDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<GetTeacherModel> Teachers { get; set; }
    }
}
