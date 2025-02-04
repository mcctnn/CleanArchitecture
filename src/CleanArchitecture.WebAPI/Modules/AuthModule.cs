using CleanArchitecture.Application.Auth;
using MediatR;
using TS.Result;

namespace CleanArchitecture.WebAPI.Modules
{
    public static class AuthModule
    {
        public static void RegisterAuthRoutes(this IEndpointRouteBuilder app)
        {
            RouteGroupBuilder group = app.MapGroup("/auth").WithTags("Auth");

            group.MapPost("login",
                async (ISender sender, LoginCommand request, CancellationToken token) =>
                {
                    var response = await sender.Send(request, token);

                    return response.IsSuccessful
                    ? Results.Ok(response)
                    : Results.InternalServerError(response);
                })
                .Produces<Result<LoginCommandResponse>>();

        }
    }
}
