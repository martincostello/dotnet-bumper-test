// Copyright (c) Martin Costello, 2025. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(Random.Shared);

var app = builder.Build();

var summaries = new[]
{
    "Freezing",
    "Bracing",
    "Chilly",
    "Cool",
    "Mild",
    "Warm",
    "Balmy",
    "Hot",
    "Sweltering",
    "Scorching",
};

app.MapGet("/weatherforecast", (Random random) =>
{
    return Enumerable.Range(1, 5)
        .Select(index =>
            new Application.WeatherForecast(
                DateTimeOffset.Now.AddDays(index),
                random.Next(-20, 55),
                summaries[random.Next(summaries.Length)]))
        .ToArray();
});

app.Run();

namespace Application
{
    public partial class Program
    {
    }
}
