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
    public class ClubController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public ClubController(IMediator mediator, IMapper mapper) 
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClubModel>>> GetAll()
        {
            var query = new GetClubListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubModel>> Get(Guid id)
        {
            var query = new GetClubQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddClubModel addClubModel)
        {
            var command = mapper.Map<AddClubCommand>(addClubModel);
            var clubId = await mediator.Send(command);
            return Created($"{clubId}", clubId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClubModel updateClubModel)
        {
            var command = mapper.Map<UpdateClubCommand>(updateClubModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveClubCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
