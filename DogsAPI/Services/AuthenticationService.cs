using System;
using System.Net;
using DAL;
using DAL.Entities;
using DogsAPI.Abstractions;
using DogsAPI.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DogsAPI.Services
{
	public class AuthenticationService : BaseService
	{
		private readonly IJwtTokenProvider _jwtTokenProvider;
		private string CollectionName = "users";

		public AuthenticationService(MongoConnectionFactory connectionFactory, IJwtTokenProvider jwtTokenProvider) : base(connectionFactory)
		{
			_jwtTokenProvider = jwtTokenProvider;
		}

		public async Task<Results<Ok<string>, ProblemHttpResult>> login(string email) {
			var collection = _connectionFactory.getCollection<User>(CollectionName);
			
			var filter = Builders<User>.Filter.Eq("Email", email);

			User user = await collection.Find(filter).SingleOrDefaultAsync();
			if (user is null) {
				//return Problem
				ProblemDetails details = new() {
					Title = "This email does not exist in our system.",
					Status = 404,
				};
				return TypedResults.Problem(details);
			}
			//User user = result.FirstOrDefault();
			string token = _jwtTokenProvider.Generate(user);
			return TypedResults.Ok(token);
		}
	}
}

