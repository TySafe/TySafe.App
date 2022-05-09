using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TySafe.Api.Common.Infrastructure.Configuration;

/// <summary>
/// Extension methods for App Configuration in microservices
/// </summary>
public static class AppConfigurationExtensions
{
	public static IHostBuilder ConfigureSharedAppConfiguration(this IHostBuilder builder) =>
		builder.ConfigureAppConfiguration((context, config) =>
		{
			config
#if DEBUG				
				.AddJsonFile("../TySafe.Api.Common/sharedsettings.json", optional: true, reloadOnChange: true)
#endif			
				.AddJsonFile("sharedsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"sharedsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true)
				
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
		});
}