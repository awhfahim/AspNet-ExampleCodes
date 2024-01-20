var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

var books = new[]
{
    new Book("Bangla","fahim",2323,"Bandladesh")
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/book", () =>
{
    return books;
});

app.MapPut("/book/{id}", (Book book, int id) =>
{
    var buk = books[id];
    if(buk is not null)
    {
        buk.AuthorName = book.AuthorName;
        buk.Country = book.Country;
        buk.Price = book.Price;
        buk.Title = book.Title;
    }
    return Results.Ok();
})
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

internal class Book(string Title, string AuthorName, uint Price, string Country)
{
    public string Title { get; set; } = Title;
    public string AuthorName { get; set; } = AuthorName;
    public uint Price { get; set; } = Price;
    public string Country { get; set; } = Country;
}