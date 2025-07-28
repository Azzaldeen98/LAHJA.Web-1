using AutoGenerator.Interfaces;
using Infrastructure.Config;


namespace LAHJA.Generator.Config
{
    public class InfrastructureAppGenerator : IAppGenerator
    {
        public async Task GenerateAsync(string operationType)
        {
            await InfrastructureGenerator.GeneratorCodeAsync(operationType);
        }
    }
}
