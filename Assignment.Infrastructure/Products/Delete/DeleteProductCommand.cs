using MediatR;
using Assignment.Domain.Entities.Products;

namespace Assignment.Infrastructure.Products.Delete
{
    public record DeleteProductCommand(ProductId ProductId): IRequest;
}
