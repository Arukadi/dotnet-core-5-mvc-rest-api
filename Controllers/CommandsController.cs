using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Commander.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> AllCommands(
            [FromServices] CommanderContext context,
            [FromServices] IMapper mapper
        )
        {
            //var commandItems = repository.GetAllCommands();
            var commandItems = context.Commands.AsNoTracking().ToList();
            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id:int}", Name = "CommandById")]
        public ActionResult<CommandReadDto> CommandById(
            [FromServices] CommanderContext context,
            [FromServices] IMapper mapper,
            int id
        )
        {
            // var commandItem = repository.GetCommandById(id);
            var commandItem = context.Commands.Find(id);
            if (commandItem is not null)
                return Ok(mapper.Map<CommandReadDto>(commandItem));

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(
            [FromServices] CommanderContext context,
            [FromServices] IMapper mapper,
            [FromBody] CommandCreateDto commandCreateDto
        )
        {
            var commandModel = mapper.Map<Command>(commandCreateDto);
            //repository.CreateCommand(commandModel);
            //repository.SaveChanges();
            context.Commands.Add(commandModel);
            context.SaveChanges();

            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(CommandById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateCommand(
            [FromServices] CommanderContext context,
            [FromServices] IMapper mapper,
            int id,
            [FromBody] CommandUpdateDto commandUpdateDto
        )
        {
            // var commandModelFromRepo = repository.GetCommandById(id);
            var commandModelFromRepo = context.Commands.Find(id);
            if (commandModelFromRepo is null)
                return NotFound();

            mapper.Map(commandUpdateDto, commandModelFromRepo);

            //repository.UpdateCommand(commandModelFromRepo);
            //repository.SaveChanges();
            context.Commands.Update(commandModelFromRepo);
            context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public ActionResult PartialCommandUpdate(
            [FromServices] CommanderContext context,
            [FromServices] IMapper mapper,
            int id,
            JsonPatchDocument<CommandUpdateDto> patchDocument
        )
        {
            // var commandModelFromRepo = repository.GetCommandById(id);
            var commandModelFromRepo = context.Commands.Find(id);
            if (commandModelFromRepo is null)
                return NotFound();

            var commandToPatch = mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDocument.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);

            mapper.Map(commandToPatch, commandModelFromRepo);

            // repository.UpdateCommand(commandModelFromRepo);
            // repository.SaveChanges();
            context.Commands.Update(commandModelFromRepo);
            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteCommand(
            [FromServices] CommanderContext context,
            int id
        )
        {
            // var commandModelFromRepo = repository.GetCommandById(id);
            var commandModelFromRepo = context.Commands.Find(id);
            if (commandModelFromRepo is null)
                return NotFound();
            
            // repository.DeleteCommand(commandModelFromRepo);
            // repository.SaveChanges();
            context.Commands.Remove(commandModelFromRepo);
            context.SaveChanges();

            return NoContent();
        }
    }
}