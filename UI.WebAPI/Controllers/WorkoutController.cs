using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsAndQueries;
using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace UI.WebAPI
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public WorkoutController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<WorkoutModel>>> GetAll()
        {
            var query = new GetWorkoutListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutModel>> Get(Guid id)
        {
            var query = new GetWorkoutQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddWorkoutModel addWorkoutModel)
        {
            var command = mapper.Map<AddWorkoutCommand>(addWorkoutModel);
            var workoutId = await mediator.Send(command);
            return Created($"{workoutId}", workoutId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWorkoutModel updateWorkoutModel)
        {
            var command = mapper.Map<UpdateWorkoutCommand>(updateWorkoutModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveWorkoutCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
