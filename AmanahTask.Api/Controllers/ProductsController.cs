using AmanahTask.Api.DTOs;
using AmanahTask.Core.Constants;
using AmanahTask.Core.Domain;
using AmanahTask.Core.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmanahTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo productRepo, IMapper mapper)
        {
            this._productRepo = productRepo;
            this._mapper = mapper;
        }
       
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepo.GetAllAsync();
            var data = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(data);
        }

        [HttpGet("GetAllProductsOrderd")]
        public async Task<IActionResult> GetAllProductsOrderd()
        {
            var products = await _productRepo.FindAllAsync(p => true,null, p => p.Date, OrderBy.Descending);
            var data = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(data);
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
                NotFound();

            var data = _mapper.Map<ProductDto>(product);
            return Ok(data);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductDto product) 
        {
            var entity = _mapper.Map<Product>(product);
            return Ok(await _productRepo.AddAsync(entity));
        }

        [HttpPut("Update")]
        public IActionResult Update(ProductDto product)
        {
            var entity = _mapper.Map<Product>(product);
            return Ok( _productRepo.Update(entity));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        { 
            return Ok(await _productRepo.DeleteAsync(id));
        }

    }
}
