﻿using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createCommandHandler;
        private readonly UpdateAboutCommandHandler _updateCommandHandler;
        private readonly RemoveAboutCommandHandler _removeCommandHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;
        private readonly GetAboutQueryHandler _getAboutQueryHandler;

        public AboutsController(CreateAboutCommandHandler createCommandHandler,
            UpdateAboutCommandHandler updateCommandHandler,
            RemoveAboutCommandHandler removeCommandHandler,
            GetAboutByIdQueryHandler getAboutByIdQueryHandler,
            GetAboutQueryHandler getAboutQueryHandler)
        {
            _createCommandHandler = createCommandHandler;
            _updateCommandHandler = updateCommandHandler;
            _removeCommandHandler = removeCommandHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
            _getAboutQueryHandler = getAboutQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _getAboutQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetAbout(int id)
        {
            var value=await _getAboutByIdQueryHandler.Handle(new GetAboutByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("About me information added");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            await _removeCommandHandler.Handle(new RemoveAboutCommand(id));
            return Ok("About me information was deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _updateCommandHandler.Handle(command);
            return Ok("About me information has been updated");
        }
    }
}
