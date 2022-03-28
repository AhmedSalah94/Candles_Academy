using AutoMapper;
using Candles_Academy.Dtos;
using Candles_Academy.Models;
using Candles_Academy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Candles_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITeachersService _teachersService;
        private readonly ICoursesRepository _coursesService;

        private new List<string> _allowedExtenstions = new List<string> { ".jpg", ".png" };
        private long _maxAllowedPosterSize = 1048576;

        public TeachersController(ITeachersService teachersService, ICoursesRepository coursesService, IMapper mapper)
        {
            _teachersService = teachersService;
            _coursesService = coursesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teachers = await _teachersService.GetAll();

            var data = _mapper.Map<IEnumerable<TeacherDetailsDto>>(teachers);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var teacher = await _teachersService.GetById(id);

            if (teacher == null)
                return NotFound();

            var dto = _mapper.Map<TeacherDetailsDto>(teacher);

            return Ok(dto);
        }

        [HttpGet("GetTeachersByCourseId")]
        public async Task<IActionResult> GetByCourseIdAsync(int courseId)
        {
            var teachers = await _teachersService.GetAll(courseId);
            var data = _mapper.Map<IEnumerable<TeacherDetailsDto>>(teachers);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] TeacherDto dto)
        {
            if (dto.Poster == null)
                return BadRequest("Poster is required!");

            if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                return BadRequest("Only .png and .jpg images are allowed!");

            if (dto.Poster.Length > _maxAllowedPosterSize)
                return BadRequest("Max allowed size for poster is 1MB!");

            var isValidCourse = await _coursesService.IsvalidCourse(dto.CourseId);

            if (!isValidCourse)
                return BadRequest("Invalid Course ID!");

            using var dataStream = new MemoryStream();

            await dto.Poster.CopyToAsync(dataStream);

            var teacher = _mapper.Map<Teacher>(dto);

            teacher.Poster = dataStream.ToArray();

            teacher.Rate = dto.Rate;

            _teachersService.Add(teacher);

            return Ok(teacher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] TeacherDto dto)
        {
            var teacher = await _teachersService.GetById(id);

            if (teacher == null)
                return NotFound($"No teacher was found with ID {id}");

            var isValidCourse = await _coursesService.IsvalidCourse(dto.CourseId);

            if (!isValidCourse)
                return BadRequest("Invalid course ID!");

            if (dto.Poster != null)
            {
                if (!_allowedExtenstions.Contains(Path.GetExtension(dto.Poster.FileName).ToLower()))
                    return BadRequest("Only .png and .jpg images are allowed!");

                if (dto.Poster.Length > _maxAllowedPosterSize)
                    return BadRequest("Max allowed size for poster is 1MB!");

                using var dataStream = new MemoryStream();

                await dto.Poster.CopyToAsync(dataStream);

                teacher.Poster = dataStream.ToArray();
            }

            
            teacher.CourseId = dto.CourseId;
            teacher.Name = dto.Name;
            teacher.Rate = dto.Rate;
            _teachersService.Update(teacher);

            return Ok(teacher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var teacher = await _teachersService.GetById(id);

            if (teacher == null)
                return NotFound($"No teacher was found with ID {id}");

            _teachersService.Delete(teacher);

            return Ok(teacher);
        }
    }
}
