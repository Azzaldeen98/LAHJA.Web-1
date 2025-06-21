using AutoGenerator.Interfaces;
using Infrastructure.Config;


namespace LAHJA.Generator.Config
{
    public class InfrastructureAppGenerator : IAppGenerator
    {
        public async Task GenerateAsync()
        {
            await InfrastructureGenerator.GeneratorCodeAsync();
        }
    }
}
