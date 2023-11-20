using Assignment.Domain.Entities.Products;
using Assignment.Domain.Products;
using Assignment.Infrastructure.Data;
using MediatR;

namespace Assignment.Infrastructure.Products.Create
{
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                new ProductId(Guid.NewGuid()),
                request.Name,
                new Money(request.Currency, request.Amount),
                StockUnit.Create(request.StockUnit)!
                );
            _productRepository.Add(product);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
