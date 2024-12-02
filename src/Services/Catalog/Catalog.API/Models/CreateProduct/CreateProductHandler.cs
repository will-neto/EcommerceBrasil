using BuildingBlocks.CQRS;

namespace Catalog.API.Models.CreateProduct
{

    public record CreateProductCommand(string Name, IList<string> Category, string Description, string ImageFile, decimal Price)
         : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category.ToList(),
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //TODO: save in db
            // ... 

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
