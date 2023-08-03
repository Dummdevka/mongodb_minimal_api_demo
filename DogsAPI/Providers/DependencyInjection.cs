using System;
using DogsAPI.Abstractions;

namespace DogsAPI.Providers;

public static class DependencyInjection
{
	public static IServiceCollection addProviders(this IServiceCollection services) {
		return services.AddScoped<IJwtTokenProvider, JwtTokenProvider>();
	}
}

