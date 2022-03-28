using Candles_Academy.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candles_Academy.Services
{
    public class TeachersService : ITeachersService
    {
        private readonly ApplicationDbContext _context;

        public TeachersService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Teacher> Add(Teacher teacher)
        {
            await _context.AddAsync(teacher);
            _context.SaveChanges();

            return teacher;
        }

        public Teacher Delete(Teacher teacher)
        {
            _context.Remove(teacher);
            _context.SaveChanges();

            return teacher;
        }

        public async Task<IEnumerable<Teacher>> GetAll(int courseId = 0)
        {
            return await _context.Teachers
                .Where(m => m.CourseId == courseId || courseId == 0)  //سواء بعت باراميتر او لا اعمل كذا
                .Include(m => m.Course)
                .ToListAsync();
        }

        public async Task<Teacher> GetById(int id)
        {
            return await _context.Teachers.Include(m => m.Course).SingleOrDefaultAsync(m => m.Id == id);
        }

        public Teacher Update(Teacher teacher)
        {
            _context.Update(teacher);
            _context.SaveChanges();

            return teacher;
        }


    }
}
