using System;
using DogsAPI.Abstractions;

namespace DogsAPI.Services;

public static class DependencyInjection
{
	public static IServiceCollection addServices(this IServiceCollection services) {
		return services.AddScoped<DogsService>()
						.AddScoped<CharitiesService>()
						.AddScoped<AuthenticationService>();
	}
}

