using Microsoft.Extensions.DependencyInjection;

namespace Brewup.Modules.Sagas;

public static class SagasHelper
{
	public static IServiceCollection AddSagas(this IServiceCollection services)
	{
		services.AddScoped<SalesOrderSaga>();

		return services;
	}
}