using Microsoft.Extensions.Hosting;
using Serilog;

namespace TySafe.Api.Common.Infrastructure.Logging;

/// <summary>
/// Logging extensions for TySafe Microservices.
/// </summary>
public static class LoggingExtensions
{
	/// <summary>
	/// Sets up the logging system, using Serilog.
	/// </summary>
	public static IHostBuilder SetupLogging(this IHostBuilder builder) =>
		builder.UseSerilog((hostingContext, loggerConfiguration) =>
		{
			loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration);
		});
	
	
}