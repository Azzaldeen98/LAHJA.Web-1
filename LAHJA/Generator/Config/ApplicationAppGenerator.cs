using Application.Config;
using AutoGenerator.Interfaces;


namespace LAHJA.Generator.Config
{
    public class ApplicationAppGenerator : IAppGenerator
    {
        public async Task GenerateAsync()
        {
            await ApplicationGenerator.GeneratorCodeAsync();
        }
    }
}
