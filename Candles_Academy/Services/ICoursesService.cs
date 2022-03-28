using Candles_Academy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candles_Academy.Services
{
    public interface ICoursesRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetById(int id);
        Task<Course> Add(Course course);
        Task<Course> Update(Course course);
        Task<int> Delete(Course course);
        Task<bool> IsvalidCourse(int id);
        Task<Course> GetCourseById(int id);
    }
}