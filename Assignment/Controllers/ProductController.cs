using Assignment.Domain.Entities.Products;
using Assignment.Domain.Products;
using Assignment.Infrastructure.Products.Create;
using Assignment.Infrastructure.Products.Delete;
using Assignment.Infrastructure.Products.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vantlogix.Infrastructure.Products.Update;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("products")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }

    [HttpGet("products")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var result = await _mediator.Send(new GetProductsQuery());
            return Ok(result);
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpGet("products/{id:guid}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetProductQuery(new ProductId(id)));
            return Ok(result);
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("products/{id:guid}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductRequest request)
    {
        var command = new UpdateProductCommand(
            new ProductId(id),
            request.Name,
            request.StockUnit,
            request.Currency,
            request.Amount
        );

        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("products/{id:guid}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            await _mediator.Send(new DeleteProductCommand(new ProductId(id)));
            return NoContent();
        }
        catch (ProductNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}
