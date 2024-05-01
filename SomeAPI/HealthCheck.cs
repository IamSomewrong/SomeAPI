using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace SomeAPI
{
    public class HealthCheck : IHealthCheck
    {
        Random r = new Random();
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if(r.Next(100) > 50)
            {
                return Task.FromResult(HealthCheckResult.Healthy("Healthy result!"));
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("Unhealthy result!"));
            }
        }
    }
}
