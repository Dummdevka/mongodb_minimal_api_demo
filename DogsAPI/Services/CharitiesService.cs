using System;
using DAL;
using DAL.Entities;
using DogsAPI.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace DogsAPI.Services;

public class CharitiesService : BaseService
{
	private const string CollectionName = "charities";

	public CharitiesService(MongoConnectionFactory connectionFactory) : base(connectionFactory) { }


	public async Task<Results<Ok<Charity>, BadRequest>> makeCharity(decimal amount, string? name) {
		Charity charity = new Charity { Amount = amount, Name = name };
		var collection = _connectionFactory.getCollection<Charity>(CollectionName);
		try {
			await collection.InsertOneAsync(charity);
		} catch (MongoWriteConcernException ex) {
			return TypedResults.BadRequest();
		}
		
		return TypedResults.Ok(charity);
	}

	public async Task<Ok<List<Charity>>> getCharitiesByName(string name) {
		var collection = _connectionFactory.getCollection<Charity>(CollectionName);
		var filter = Builders<Charity>.Filter.Eq("Name", name);
		var charities = await collection.FindAsync(filter);
		return TypedResults.Ok(charities.ToList());
	}
}

