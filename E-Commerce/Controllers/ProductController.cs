using AutoMapper;
using E_Commerce.Business.Services;
using E_Commerce.Business.Dtos;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.Business.Exceptions;
using E_Commerce.Shared.Models;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly Service<Product, ProductDto> _productService;
    private readonly IMapper _mapper;

    public ProductController(Service<Product, ProductDto> productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
    {
        try
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        try
        {
            var product = await _productService.GetByIdAsync(id, "Category");

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (Exception ex)
        {
            // Handle exceptions
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDto)
    {
        try
        {
            var createdProduct = await _productService.CreateAsync(productDto);
            return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
        }
        catch (BusinessException ex)
        {
            // Handle business exceptions
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductDto productDto)
    {
        try
        {
            var updatedProduct = await _productService.UpdateAsync(id, productDto);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }
        catch (BusinessException ex)
        {
            // Handle business exceptions
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteProduct(int id)
    {
        try
        {
            await _productService.DeleteAsync(id);
            return Ok(1);
        }
        catch (BusinessException ex)
        {
            // Handle business exceptions
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            return StatusCode(500, ex.Message);
        }
    }
}