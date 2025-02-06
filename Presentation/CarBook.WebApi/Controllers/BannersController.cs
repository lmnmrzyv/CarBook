using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using CarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly CreateBannerCommandHandler _createCommandHandler;
        private readonly UpdateBannerCommandHandler _updateCommandHandler;
        private readonly RemoveBannerCommandHandler _removeCommandHandler;

        public BannersController(GetBannerByIdQueryHandler getBannerByIdQueryHandler,
            GetBannerQueryHandler getBannerQueryHandler,
            CreateBannerCommandHandler createCommandHandler,
            UpdateBannerCommandHandler updateCommandHandler,
            RemoveBannerCommandHandler removeCommandHandler)
        {
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _createCommandHandler = createCommandHandler;
            _updateCommandHandler = updateCommandHandler;
            _removeCommandHandler = removeCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var values = await _getBannerQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetBanner(int id)
        {
            var value=await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("About me information added");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBanner(int id)
        {
            await _removeCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("About me information was deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _updateCommandHandler.Handle(command);
            return Ok("About me information has been updated");
        }
    }

}
