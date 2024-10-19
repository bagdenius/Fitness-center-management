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
    public class UserController : BaseController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            var query = new GetUserListQuery { };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(Guid id)
        {
            var query = new GetUserQuery { Id = id };
            var vm = await mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Add([FromBody] AddUserModel addUserModel)
        {
            var command = mapper.Map<AddUserCommand>(addUserModel);
            var userId = await mediator.Send(command);
            return Created($"{userId}", userId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserModel updateUserModel)
        {
            var command = mapper.Map<UpdateUserCommand>(updateUserModel);
            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var command = new RemoveUserCommand { Id = id };
            await mediator.Send(command);
            return NoContent();
        }
    }
}
