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
    public class ClubPassController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public ClubPassController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClubPassModel>>> GetAll()
        {
            var query = new GetClubPassListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClubPassModel>> Get(Guid id)
        {
            var query = new GetClubPassQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddClubPassModel addClubPasModel)
        {
            var command = mapper.Map<AddClubPassCommand>(addClubPasModel);
            var clubPass = await mediator.Send(command);
            return Created($"{clubPass}", clubPass);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClubPassModel updateClubPassModel)
        {
            var command = mapper.Map<UpdateClubPassCommand>(updateClubPassModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveClubPassCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
