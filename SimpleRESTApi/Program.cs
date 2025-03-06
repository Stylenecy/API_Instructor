using System.Text;
using SimpleRESTApi.Data;
using SimpleRESTApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Dependency Injection
builder.Services.AddSingleton<interfaceCategory, DataAccessLayerCategory>();
builder.Services.AddSingleton<interfaceInstructor, DataAccessLayerInstructor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// app.MapGet("api/v1/helloservices", (string?id) => $"Hello ASP Web API: id={id}");

// app.MapGet("api/v1/helloservices/{name}", (string name) => $"Hello {name}!");

// app.MapGet("api/v1/luas-segitiga", (double alas, double tinggi)
//  =>{
//     double luas = 0.5 * alas * tinggi;
//     return $"Luas segitiga dengan alas = {alas} dan tinggi = {tinggi} adalah {luas} ";
//  });

// app.MapGet("api/v1/categories/{id}",(ICategory categoryData, int id)=>
// {
//     var category = categoryData.GetCategoryById(id);
//     return category;
// });

// app.MapPost("api/v1/categories", (ICategory categoryData, Category category) =>
// {
//     var newCategory = categoryData.AddCategory(category);
//     return newCategory;
// });

// app.MapPut("api/v1/categories", (ICategory categoryData, Category category) =>
// {
//     var updatedCategory = categoryData.UpdateCategory(category);
//     return updatedCategory;
// });


app.MapPut("api/v1/categories", (interfaceCategory categoryData, Category category) =>
{
    return categoryData.UpdateCategory(category);
});

app.MapDelete("api/v1/categories/{id}", (interfaceCategory categoryData, int id) =>
{
    categoryData.DeleteCategory(id);
    return Results.Ok("Category deleted");
});

app.MapGet("api/v1/categories", (interfaceCategory categoryData) =>
{
    var categories = categoryData.GetCategories();
    return categories;
});

app.MapGet("api/v1/categories/{id}", (interfaceCategory categoryData, int id) =>
{
    var category = categoryData.GetCategoryById(id);
    return category;
});

app.MapPost("api/v1/categories", (interfaceCategory categoryData, Category category) =>
{
    var newCategory = categoryData.AddCategory(category);
    return newCategory;
});

app.MapGet("api/v1/instructors", (interfaceInstructor InstructorData) =>
{
    var instructors = InstructorData.GetInstructors();
    return instructors;
});

app.MapGet("api/v1/instructors/{id}", (interfaceInstructor InstructorData, int id) =>
{
    var instructor = InstructorData.GetInstructorById(id);
    return instructor;
});

app.MapPost("api/v1/instructors", (interfaceInstructor InstructorData, Instructor instructor) =>
{
    var newInstructor = InstructorData.AddInstructor(instructor);
    return newInstructor;
});

app.MapPut("api/v1/instructors", (interfaceInstructor InstructorData, Instructor instructor) =>
{
    return InstructorData.UpdateInstructor(instructor);
});

app.MapDelete("api/v1/instructors/{id}", (interfaceInstructor InstructorData, int id) =>
{
    InstructorData.DeleteInstructor(id);
    return "Instructor deleted";
});

app.Run();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     /// <summary>
//     /// Generates an array of WeatherForecast objects with random temperature and summary values.
//     /// </summary>
//     /// <returns>An array of WeatherForecast objects.</returns>
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }