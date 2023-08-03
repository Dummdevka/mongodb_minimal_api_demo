using DAL;
using DAL.Entities;
using DogsAPI.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DogsAPI.Services;

public class DogsService: BaseService
{
	//private readonly MongoConnectionFactory _connectionFactory;
	private const string CollectionName = "dogs";

	public DogsService(MongoConnectionFactory connectionFactory) : base(connectionFactory) {
		//_connectionFactory = connectionFactory;
	}

	public async Task<Ok<List<Dog>>> getDogs() {
		var collection = _connectionFactory.getCollection<Dog>(CollectionName);

		var dogs = await collection.FindAsync(_ => true);

		return TypedResults.Ok(dogs.ToList());
	}

	public async Task<Results<Ok<Dog>, NotFound>> adoptDog(string id) {
		var collection = _connectionFactory.getCollection<Dog>(CollectionName);

		var filter = Builders<Dog>.Filter.Eq("Id", id);
		Dog updatedDog = await collection.Find(filter).SingleOrDefaultAsync();
		if (updatedDog is null) {
			return TypedResults.NotFound();
		}
		//Dog updatedDod = result.Firs
		updatedDog.Adopted = true;
		updatedDog.DateAdopted = DateTime.Now.ToString("yyyy-MM-dd");
		await collection.ReplaceOneAsync(filter, updatedDog, new UpdateOptions { IsUpsert = true });

		return TypedResults.Ok(updatedDog);
	}

	public async Task<Results<Created<Dog>,ProblemHttpResult>> addDog(Dog dog) {
		var collection = _connectionFactory.getCollection<Dog>(CollectionName);
		try {
			await collection.InsertOneAsync(dog);
		} catch (MongoWriteConcernException ex) {
			ProblemDetails details = new() {
				Title = "Dog could not be created",
				Detail = "Make sure that dog's name is unique!",
				Status = 422
			};
			return TypedResults.Problem(details);
		}
		
		return TypedResults.Created($"/api/dog/{dog.Id}", dog);
	}
}

