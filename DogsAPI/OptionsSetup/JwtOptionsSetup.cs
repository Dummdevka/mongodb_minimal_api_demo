using System;
using DogsAPI.Options;
using Microsoft.Extensions.Options;

namespace DogsAPI.OptionsSetup;

public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
{
	private readonly string SectionName = "Jwt";
	private readonly IConfiguration _config;
	public JwtOptionsSetup(IConfiguration config)
	{
		_config = config;
	}

	public void Configure(JwtOptions options) {
		_config.GetSection(SectionName).Bind(options);
	}
}

