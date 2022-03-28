using Candles_Academy.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candles_Academy.Services
{
    public class CourseRepository : ICoursesRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Course> Add(Course course)
        {
            await _context.AddAsync(course);
            _context.SaveChanges();

            return course;
        }

        public async Task<int> Delete(Course course)
        {
            _context.Remove(course);
         await   _context.SaveChangesAsync();

            return course.Id;
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses.OrderBy(g => g.Name).ToListAsync();
        }

        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.AsNoTracking().FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Course> GetCourseById(int id)
        {
            return await _context.Courses.Include(c=>c.Teachers).FirstOrDefaultAsync(g => g.Id == id);

        }

        public Task<bool> IsvalidCourse(int id)
        {
            return _context.Courses.AnyAsync(g => g.Id == id);
        }

        public async Task<Course> Update(Course course)
        {
            _context.Update(course);
         await   _context.SaveChangesAsync();

            return course;
        }
    }
}
