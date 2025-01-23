﻿using CleanArchitecture.Application.Employees;
using MediatR;
using TS.Result;

namespace CleanArchitecture.WebAPI.Modules;

public static class EmployeeModule
{
    public static void RegisterEmployeeRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/employees").WithTags("Employees");

        group.MapPost(string.Empty,
            async (ISender sender, EmployeeCreateCommand request, CancellationToken token) =>
            {
                var response = await sender.Send(request, token);

                return response.IsSuccessful
                ? Results.Ok(response)
                : Results.InternalServerError(response);
            })
            .Produces<Result<string>>();

    }
}
