using System;
using DAL.Entities;
using DogsAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DogsAPI.Routes;

public static class DogsApi
{
	public static void mapDogs(this IEndpointRouteBuilder app) {
		app.MapGet("/api/dogs", getAllDogs);
		app.MapPut("/api/dogs/adopt/{id}", adoptDog);
		app.MapPost("api/dogs", addDog).RequireAuthorization();
	}

	
	public static async Task<Ok<List<Dog>>> getAllDogs([FromServices] DogsService service) {
		return await service.getDogs();
	}

	public static async Task<Results<Ok<Dog>, NotFound>> adoptDog(string id, [FromServices] DogsService service) {
		return await service.adoptDog(id);
	}

	public static async Task<Results<Created<Dog>, ProblemHttpResult>> addDog(Dog dog, [FromServices] DogsService service, IValidator<Dog> validator) {
		var validation = await validator.ValidateAsync(dog);
		if (validation.IsValid) {
			return await service.addDog(dog);
		} else {
			return TypedResults.Problem((ProblemDetails)validation.ToDictionary());
		}
		
	}
}

