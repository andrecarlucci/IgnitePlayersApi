using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace PlayersApi {
    public class MyHealthCheck : IHealthCheck {
        private readonly IPlayersRepository _playersRepository;

        public MyHealthCheck(IPlayersRepository playersRepository) {
            _playersRepository = playersRepository;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default(CancellationToken)) {
            if(await _playersRepository.IsUp()) {
                return HealthCheckResult.Healthy();
            }
            return HealthCheckResult.Unhealthy();
        }
    }
}