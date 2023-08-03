using DAL;
using DAL.Entities;
using DogsAPI.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace DogsAPI.Services;

public class CharitiesService : BaseService
{
	private const string CollectionName = "charities";

	public CharitiesService(MongoConnectionFactory connectionFactory) : base(connectionFactory) { }


	public async Task<Ok<Charity>> makeCharity(Charity charity) {
		//Charity charity = new Charity { Amount = amount, Name = name };
		var collection = _connectionFactory.getCollection<Charity>(CollectionName);

		await collection.InsertOneAsync(charity);
		
		
		return TypedResults.Ok(charity);
	}

	public async Task<Ok<List<Charity>>> getCharitiesByName(string name) {
		var collection = _connectionFactory.getCollection<Charity>(CollectionName);
		var filter = Builders<Charity>.Filter.Eq("Name", name);
		var charities = await collection.FindAsync(filter);
		return TypedResults.Ok(charities.ToList());
	}
}

