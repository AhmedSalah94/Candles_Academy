using Candles_Academy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candles_Academy.Services
{
    public interface ITeachersService
    {

        Task<IEnumerable<Teacher>> GetAll(int courseId = 0);  //optional param
        Task<Teacher> GetById(int id);
        Task<Teacher> Add(Teacher teacher);
        Teacher Update(Teacher teacher);
        Teacher Delete(Teacher teacher);

    }
}
