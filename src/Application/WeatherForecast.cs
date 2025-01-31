// Copyright (c) Martin Costello, 2025. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

namespace Application;

/// <summary>
/// Represents a weather forecast.
/// </summary>
/// <param name="Date">The date.</param>
/// <param name="TemperatureC">The temperature in degrees Celsius.</param>
/// <param name="Summary">The summary.</param>
/// <returns></returns>
public record WeatherForecast(DateTimeOffset Date, int TemperatureC, string? Summary)
{
    /// <summary>
    /// Gets the temperature in degrees Fahrenheit.
    /// </summary>
    /// <returns></returns>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
