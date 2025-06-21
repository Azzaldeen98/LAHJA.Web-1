using FluentValidation;
using Microsoft.AspNetCore.Components.Server.Circuits;
using MudBlazor;
using Shared.Interfaces;


namespace LAHJA.Services.Infrastructure
{




    public class CustomCircuitHandler : CircuitHandler,ITSingleton
    {
        private readonly ILogger<CustomCircuitHandler> _logger;

        public CustomCircuitHandler(ILogger<CustomCircuitHandler> logger)
        {
            _logger = logger;
        }

        public override Task OnCircuitOpenedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            _logger.LogInformation("🎉 Circuit opened: ", circuit.Id);
            return Task.CompletedTask;
        }

        public override Task OnCircuitClosedAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            _logger.LogWarning("⚠️ Circuit closed: ", circuit.Id);
            return Task.CompletedTask;
        }

        public override Task OnConnectionDownAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            _logger.LogWarning("📡 Connection temporarily lost: ", circuit.Id);
            return Task.CompletedTask;
        }

        public override Task OnConnectionUpAsync(Circuit circuit, CancellationToken cancellationToken)
        {
            _logger.LogInformation("🔌 Connection returned: ", circuit.Id);
            return Task.CompletedTask;
        }
    }

}
