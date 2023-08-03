using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace DAL;

public class MongoConnectionFactory
{
	private readonly IConfiguration _configuration;
	private const string DatabaseName = "kennel";

	public MongoConnectionFactory(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public IMongoCollection<T> getCollection<T>(in string collectionName) {
		var connector = new MongoClient(_configuration.GetConnectionString("Mongo"));
		IMongoDatabase document = connector.GetDatabase(DatabaseName);
		return document.GetCollection<T>(collectionName);
	}
}

