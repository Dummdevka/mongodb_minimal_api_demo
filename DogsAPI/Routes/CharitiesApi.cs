using System;
using DAL.Entities;
using DogsAPI.Abstractions;
using DogsAPI.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DogsAPI.Routes
{
	public static class CharitiesApi
	{
		
		public static void mapCharities(this IEndpointRouteBuilder app) {
			app.MapGet("/api/charirties/{name}", getCharitiesByName);
			app.MapPost("/api/charities", makeCharity);
		}

		public static async Task<Ok<List<Charity>>> getCharitiesByName(string name, [FromServices] CharitiesService service) {
			return await service.getCharitiesByName(name);
		}

		public static async Task<Results<Ok<Charity>, BadRequest>> makeCharity(decimal amount, string? name, [FromServices] CharitiesService service) {
			return await service.makeCharity(amount, name);
		}
	}
}

