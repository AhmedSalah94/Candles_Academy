using AutoMapper;
using Candles_Academy.Dtos;
using Candles_Academy.Models;
using Candles_Academy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candles_Academy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {

        private readonly ICoursesRepository _coursesService;
        private readonly IMapper _mapper;

        public CoursesController(ICoursesRepository CoursesService, IMapper mapper)
        {
            _coursesService = CoursesService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var courses = await _coursesService.GetAll();

            return Ok(courses);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _coursesService.GetCourseById(id);
            var  courseDetails =_mapper.Map<GetCourseDetails>(course);
            return Ok(courseDetails);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(PostCourseDto model)
        {
            var course = _mapper.Map<Course>(model);
            await _coursesService.Add(course);

            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, PutCourseDto model)
        {
            var course = await _coursesService.GetById(id);

            if (course == null)
                return NotFound($"No course was found with ID: {id}");

            var updatedCourse = _mapper.Map<Course>(model);



            await _coursesService.Update(updatedCourse);

            return Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var course = await _coursesService.GetById(id);

            if (course == null)
                return NotFound($"No course was found with ID: {id}");

           await _coursesService.Delete(course);

            return Ok(id);
        }

    }
}