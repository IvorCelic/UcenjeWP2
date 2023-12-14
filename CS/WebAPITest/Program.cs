var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


// "/shirts"
app.MapGet("/books", () =>
    {
        return "Izlistavam sve knjige";
    });

app.MapGet("/books/{ID}", (int ID) =>
    {
        return $"Izlistavam knjigu: {ID}";
    });

app.MapPost("/books", () =>
    {
        return "Kreiram knjigu.";
    });

app.MapPut("/books/{ID}", (int ID) =>
    {
        return $"A�uriram knjigu: {ID}";
    });

app.MapDelete("/books/{ID}", (int ID) =>
    {
        return $"Bri�em knjigu: {ID}";
    });


app.Run();


