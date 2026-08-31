using CourseService.Application.Courses.Commands.CourseCommand;
using CourseService.Application.Courses.DTOs;
using CourseService.Application.Courses.Queries.GetCourseById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create(CreateCourseCommand command, CancellationToken cancellationToken)
        {
            var courseId = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = courseId }, courseId);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CourseDto>> GetById(Guid id, CancellationToken cancellationToken)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery(id), cancellationToken);
            return Ok(course);
        }
    }
} 
