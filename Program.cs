var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var products = new[]
{
    new Product(1, "Teclado mecanico", 120000m),
    new Product(2, "Mouse inalambrico", 65000m),
    new Product(3, "Monitor 24 pulgadas", 540000m),
};

var personas = new[]
{
    new Persona("1", "Santiago", "Zuleta", 20),
    new Persona("2", "Andres", "Zuleta", 40),
    new Persona("3", "Diego", "Zuleta", 60),
};

app.MapGet("/", () => "dotnet-example OK");
app.MapGet("/products", () => products);
app.MapGet("/personas", () => personas);

app.Run();

record Product(int Id, string Name, decimal Price);
record Persona(string Id, string Nombre, string Apellido, int Edad);
