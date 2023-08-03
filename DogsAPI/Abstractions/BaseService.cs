using System;
using DAL;

namespace DogsAPI.Abstractions
{
	public abstract class BaseService
	{
		internal readonly MongoConnectionFactory _connectionFactory;
		public virtual string CollectionName { get; set; }

		public BaseService(MongoConnectionFactory connectionFactory) {
			_connectionFactory = connectionFactory;
		}
	}
}

