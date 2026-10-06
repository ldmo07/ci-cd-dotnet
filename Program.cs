var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var products = new[]
{
    new Product(1, "Teclado mecanico", 120000m),
    new Product(2, "Mouse inalambrico", 65000m),
    new Product(3, "Monitor 24 pulgadas", 540000m),
};

app.MapGet("/", () => "dotnet-example OK");
app.MapGet("/products", () => products);

app.Run();

record Product(int Id, string Name, decimal Price);
