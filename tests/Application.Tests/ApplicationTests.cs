// Copyright (c) Martin Costello, 2025. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.

using Microsoft.AspNetCore.Mvc.Testing;

namespace Application;

public static class ApplicationTests
{
    [Fact]
    public static async Task Can_Get_Weather_Forecast()
    {
        // Arrange
        var factory = new WebApplicationFactory<Program>();

        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("/weatherforecast");

        // Assert
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        Assert.NotNull(content);
    }
}
