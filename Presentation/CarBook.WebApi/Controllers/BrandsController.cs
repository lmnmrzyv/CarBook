using CarBook.Application.Features.CQRS.Commands.BrandCommands;
using CarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly GetBrandQueryHandler _getBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;
        private readonly CreateBrandCommandHandler _createCommandHandler;
        private readonly UpdateBrandCommandHandler _updateCommandHandler;
        private readonly RemoveBrandCommandHandler _removeCommandHandler;

        public BrandsController(GetBrandQueryHandler getBrandQueryHandler, 
            GetBrandByIdQueryHandler getBrandByIdQueryHandler,
            CreateBrandCommandHandler createCommandHandler, 
            UpdateBrandCommandHandler updateCommandHandler, 
            RemoveBrandCommandHandler removeCommandHandler)
        {
            _getBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
            _createCommandHandler = createCommandHandler;
            _updateCommandHandler = updateCommandHandler;
            _removeCommandHandler = removeCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await _getBrandQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBrand(int id)
        {
            var values= await _getBrandByIdQueryHandler.Handle(new GetBrandByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _createCommandHandler.Handle(command);
            return Ok("About me information added");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBrand(int id)
        {
            await _removeCommandHandler.Handle(new RemoveBrandCommand(id));
            return Ok("About me information was deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _updateCommandHandler.Handle(command);
            return Ok("About me information has been updated");
        }
    }
}
