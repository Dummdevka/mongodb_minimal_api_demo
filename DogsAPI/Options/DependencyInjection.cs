using System;
namespace DogsAPI.Options;

public static class DependencyInjection
{
	public static IServiceCollection addOptions(this IServiceCollection services) {
		return services.AddSingleton<JwtOptions>();
	}
}

