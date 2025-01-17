using Marten.Schema;

namespace Catalog.API.FakeData
{
    public class FakeDataHandler : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync()) return;

            session.Store(handlerDb());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> handlerDb() =>
            [
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "IPhone X",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageUrl = "product-1.png",
                    Price = 950.00M,
                    Categories = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Samsung 10",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageUrl = "product-2.png",
                    Price = 840.00M,
                    Categories = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Huawei Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageUrl = "product-3.png",
                    Price = 650.00M,
                    Categories = new List<string> { "White Appliances" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Xiaomi Mi 9",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageUrl = "product-4.png",
                    Price = 470.00M,
                    Categories = new List<string> { "White Appliances" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "HTC U11+ Plus",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageUrl = "product-5.png",
                    Price = 380.00M,
                    Categories = new List<string> { "Smart Phone" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "LG G7 ThinQ",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageUrl = "product-6.png",
                    Price = 240.00M,
                    Categories = new List<string> { "Home Kitchen" }
                },
                new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Panasonic Lumix",
                    Description = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    ImageUrl = "product-6.png",
                    Price = 240.00M,
                    Categories = new List<string> { "Camera" }
                }
            ];
    }
}