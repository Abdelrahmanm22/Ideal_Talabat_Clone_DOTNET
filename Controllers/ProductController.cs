using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Round2Api.DTOs;
using Round2Api.Errors;
using Round2Api.Helpers;
using Round2Api.Models;
using Round2Api.Repositories.Interfaces;
using Round2Api.Specifications;

namespace Round2Api.Controllers
{
    public class ProductController : APIBaseController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<Product> productRepository
            ,IGenericRepository<ProductType> productTypeRepository
            ,IGenericRepository<ProductBrand> productBrandRepository
            ,IMapper mapper)
        {
            _productRepository = productRepository;
            _productTypeRepository = productTypeRepository;
            _productBrandRepository = productBrandRepository;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        // baseurl/api/product =>get
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productSpec)
        {
            var spec = new ProductWithBrandAndTypeSpecification(productSpec);
            var products = await _productRepository.GetAllAsync(spec);
            var productsDto = _mapper.Map<IReadOnlyList<ProductToReturnDto>>(products);
            var countSpec = new ProductWithFiltrationForCountAsync(productSpec);
            var count = await _productRepository.GetCountWithSpecAsync(countSpec);
            
            return Ok(new Pagination<ProductToReturnDto>(productSpec.PageSize,productSpec.PageIndex,count,productsDto));
        }
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDto),200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        [ProducesResponseType(typeof(ApiResponse), 500)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithBrandAndTypeSpecification(id);
            var product = await _productRepository.GetByIdAsync(spec);
            if (product is null)
            {
                return NotFound(new ApiResponse(404));
            }
            var productDto = _mapper.Map<ProductToReturnDto>(product);
            return Ok(productDto);
        }
        [Authorize]
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypes()
        {
            var types = await _productTypeRepository.GetAllAsync();
            return Ok(types);
        }
        [Authorize]
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrands()
        {
            var brands = await _productBrandRepository.GetAllAsync();
            return Ok(brands);
        }
    }
}
