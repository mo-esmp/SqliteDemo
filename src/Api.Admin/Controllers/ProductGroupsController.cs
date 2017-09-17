using Api.Admin.ViewModels;
using AutoMapper;
using Core.Products;
using Core.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Admin.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductGroupsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductGroupsController(IMediator mediator, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mediator = mediator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        // GET api/v1/ProductGroup/id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var productGroup = await _mediator.Send(new ProductGroupGetQuery { ProductGroupId = id });
            var productGroupDto = _mapper.Map<ProductGroupDto>(productGroup);

            return Ok(productGroupDto);
        }

        // POST api/v1/ProductGroup/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductGroupAddViewModel viewModel)
        {
            if (viewModel.Icon == null)
                viewModel.Icon = GetIconBinary();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<ProductGroupEntity>(viewModel);

            var operationResult = await _mediator.Send(new ProductGroupAddCommand { ProductGroup = entity });

            if (!operationResult.Succeeded)
                return BadRequest(operationResult.ErrorMessages);

            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, null);
        }

        // Put api/v1/ProductGroup/id
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProductGroupEditViewModel viewModel)
        {
            if (viewModel.Icon == null)
                viewModel.Icon = GetIconBinary();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<ProductGroupEntity>(viewModel);
            entity.Id = id;

            var operationResult = await _mediator.Send(new ProductGroupEditCommand { ProductGroup = entity });

            if (!operationResult.Succeeded)
                return BadRequest(operationResult.ErrorMessages);

            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, null);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var operationResult = await _mediator.Send(new ProductGroupRemoveCommand { ProductGroupId = id });
            if (!operationResult.Succeeded)
                return BadRequest(operationResult.ErrorMessages);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        private byte[] GetIconBinary()
        {
            var path = Directory.GetDirectories(Directory.GetCurrentDirectory(), "Resources").First();
            return System.IO.File.ReadAllBytes($"{path}/194x194.png");
        }
    }
}