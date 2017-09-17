using Api.Admin.ViewModels;
using AutoMapper;
using Core.Products;
using Core.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Admin.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductGroupTypesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductGroupTypesController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        // GET: api/v1/productGroupTypes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productGroupType = await _mediator.Send(new ProductGroupTypeGetsQuery());
            var productGroupTypeDto = _mapper.Map<IEnumerable<ProductGroupTypeDto>>(productGroupType);

            return Ok(productGroupTypeDto);
        }

        // GET api/v1/productGroupTypes/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var productGroupType = await _mediator.Send(new ProductGroupTypeGetQuery { ProductGroupTypeId = id });
            var productGroupTypeDto = _mapper.Map<ProductGroupTypeDto>(productGroupType);

            return Ok(productGroupTypeDto);
        }

        // POST api/v1/ProductGroupTypes
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductGroupTypeAddViewModel viewModel)
        {
            if (viewModel.Icon == null)
                viewModel.Icon = getIconBinary();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<ProductGroupTypeEntity>(viewModel);
            var operationResult = await _mediator.Send(new ProductGroupTypeAddCommand { ProductGroupType = entity });

            if (!operationResult.Succeeded)
                return BadRequest(operationResult.ErrorMessages);

            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, null);
        }

        // PUT api/v1/productGroupTypes/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody]ProductGroupTypeEditViewModel viewModel)
        {
            if (viewModel.Icon == null)
                viewModel.Icon = getIconBinary();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = _mapper.Map<ProductGroupTypeEntity>(viewModel);
            entity.Id = id;

            var operationResult = await _mediator.Send(new ProductGroupTypeEditCommand { ProductGroupType = entity });

            if (!operationResult.Succeeded)
                return BadRequest(operationResult.ErrorMessages);

            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, null);
        }

        // DELETE api/v1/productGroupTypes/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var operationResult = await _mediator.Send(new ProductGroupTypeRemoveCommand { ProductGroupTypeId = id });

            if (!operationResult.Succeeded)
                return BadRequest(operationResult.ErrorMessages);

            await _unitOfWork.SaveChangesAsync();

            return Ok();
        }

        // Hack: Yaghoub -> Mohsen - Add file upload to swagger
        private byte[] getIconBinary()
        {
            var path = Directory.GetDirectories(Directory.GetCurrentDirectory(), "Resources").First();
            return System.IO.File.ReadAllBytes($"{path}/logo.png");
        }
    }
}