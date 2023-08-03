using System;
using DAL.Entities;

namespace DogsAPI.Abstractions
{
	public interface IJwtTokenProvider
	{
		string Generate(User user);
	}
}

