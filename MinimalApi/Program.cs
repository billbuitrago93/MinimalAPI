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


#region Cars endpoints

app.MapGet("api / cars", () =>
{
    var car1 = new Car
    {
        TeamName = "Team A"
    };
    var car2 = new Car
    {
        TeamName = "Team B"
    };
    var cars = new List <Car>
    {
        car1, car2
    };

    return cars;
})
.WithName("Minimal API - GetCars")
.WithTags("Cars");



app.MapGet("api/cars/{id}",
    (int id) =>

    {
        var car1 = new Car
        {

            TeamName = "Team A"

        };
        return car1;
    })
    .WithName("GetCars")
    .WithTags("Cars");


app.MapPost("api/cars",
    (Car car) =>
    {
        return car;

    }).WithName("CreateCar")
    .WithTags("Cars");


app.MapPut("api/cars/{id}",
    (Car car) =>
    {
        return car;

    }).WithName("UpdateCar")
     .WithTags("Cars");


app.MapDelete("api/cars/{id}",
    (int id) =>
    {
        return $"Car with id: {id} was successfully deleted";

    }).WithName("DeleteCar")
    .WithTags("Cars");

#endregion

#region Motorbikes endpoints

app.MapGet("api/motorbikes", () =>
{
    var motorbike1 = new Motorbike
    {
        Id = 1000-1,
       TeamName = "Team 1"
    };
    var motorbike2 = new Motorbike
    {
        Id=1000-2,
        TeamName = "Team 2"
    };
    var motorbikes = new List<Motorbike>
    {
        motorbike1, motorbike2
    };

    return motorbikes;
})
.WithName("Minimal API - GetMotorbikes")
.WithTags("Motorbikes");



app.MapGet("api/motorbikes/{id}",
    (int id) =>

    {
        var motorbike1 = new Motorbike
        {
            Id = id,
            TeamName = "Team 1"

        };
        return motorbike1;
    })
    .WithName("GetMotorbike")
    .WithTags("Motorbikes");


app.MapPost("api/motorbikes",
    (Motorbike motorbike) =>
    {
        return motorbike;

    }).WithName("CreateMotorbike")
    .WithTags("Motorbikes");


app.MapPut("api/motorbikes/{id}",
   (Motorbike motorbike) =>
   {
       return motorbike;

   }).WithName("UpdateMotorbike")
   .WithTags("Motorbikes");


app.MapDelete("api/motorbikes/{id}",
    (int id) =>
    {
        return $"Motorbike with id: {id} was successfully deleted";

    }).WithName("DeleteMotorbike")
    .WithTags("Motorbikes");
#endregion

// Motorbike Race endpoints

#region Default endpoints
app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithTags("Defaults");

app.Run();


#endregion


#region Models
internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

public record Car
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelfunctionChance { get; set; }
    public int MelfunctionsOccured { get; set; }
    public int DistanceCoverdInMiles { get; set; }
    public bool FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}



public record Motorbike
{
    public int Id { get; set; }
    public string TeamName { get; set; }
    public int Speed { get; set; }
    public double MelfunctionChance { get; set; }
    public int MelfunctionsOccured { get; set; }
    public int DistanceCoverdInMiles { get; set; }
    public bool FinishedRace { get; set; }
    public int RacedForHours { get; set; }
}


public record MotorbikeRace
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public int Distance { get; set; }
    public int TimeLimit { get; set; }
    public string Status { get; set; }
    public List<Motorbike> Motorbikes { get; set; } = new List<Motorbike>();

}

#endregion