using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Abstractions;

public abstract class Entity
{
	[BsonId]
	[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
	[DataMember(Name ="Id", IsRequired = false, EmitDefaultValue = false)]
	public string Id {
		get; set;
	}
}

