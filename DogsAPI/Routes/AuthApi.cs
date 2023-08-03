using System;
using DogsAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DogsAPI.Routes;

public static class AuthApi
{
	public static void mapAuth(this IEndpointRouteBuilder app) {
		app.MapPut("/api/login", login);
	}

	public static async Task<Results<Ok<string>,ProblemHttpResult>> login(string email, [FromServices] AuthenticationService service) {
		return await service.login(email);
	}
}

