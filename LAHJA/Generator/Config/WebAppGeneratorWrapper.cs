using AutoGenerator.Interfaces;
using LAHJA.Generator.Code;


namespace LAHJA.Generator.Config
{
    public class WebAppGeneratorWrapper : IAppGenerator
    {
        public async Task GenerateAsync()
        {
            await WebAppGenerator.GeneratorCode();
            await WebAppGenerator.InjectorCode();
            await Task.CompletedTask; // للتوافق مع async
        }
    }
}
