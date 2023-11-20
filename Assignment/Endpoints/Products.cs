using Assignment.Domain.Entities.Products;
using Assignment.Domain.Products;
using Assignment.Infrastructure.Products.Create;
using Assignment.Infrastructure.Products.Delete;
using Assignment.Infrastructure.Products.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Assignment.Infrastructure.Products.Update;

namespace Assignment.API.Endpoints
{
    public class Products
    {
        public void AddRoutes(IEndpointRouteBuilder app) 
        {
            app.MapPost("products", async (CreateProductCommand command, ISender sender)=>
            {
                await sender.Send(command);
                return Results.Ok();
            });

            app.MapGet("products", async (ISender sender) => {
                try
                {
                    return Results.Ok(await sender.Send(new GetProductsQuery()));
                }
                catch (ProductNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            });
            app.MapGet("products/{id:guid}", async (Guid id, ISender sender) => {
                try
                {
                    return Results.Ok(await sender.Send(new GetProductQuery(new ProductId(id))));
                }
                catch (ProductNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            });
            app.MapPut("products/{id:guid}", async (Guid id, [FromBody] UpdateProductRequest request, ISender sender) => 
            {
                var command = new UpdateProductCommand(
                    new ProductId(id),
                    request.Name,
                    request.StockUnit,
                    request.Currency,
                    request.Amount
                    );
                await sender.Send(command);
                return Results.NoContent();
            });
            app.MapDelete("products/{id:guid}", async (Guid id, ISender sender)=>
            {
                try
                {
                    await sender.Send(new DeleteProductCommand(new ProductId(id)));
                    return Results.NoContent();
                }
                catch (ProductNotFoundException e)
                {
                    return Results.NotFound(e.Message);
                }
            });
        }
    }
}
