using Assignment.Domain.Entities.Products;
using Assignment.Domain.Products;
using Assignment.Infrastructure.Data;
using MediatR;

namespace Assignment.Infrastructure.Products.Update
{
    internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);
            if (product is null) 
            {
                throw new ProductNotFoundException(request.ProductId);
            }
            product.Update(
                request.Name,
                new Money(request.Currency, request.Amount),
                StockUnit.Create(request.StockUnit)!);
            _productRepository.Update(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
