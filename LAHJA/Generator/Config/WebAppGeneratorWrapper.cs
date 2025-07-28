using AutoGenerator.Interfaces;
using LAHJA.Generator.Code;


namespace LAHJA.Generator.Config
{
    public class WebAppGeneratorWrapper : IAppGenerator
    {
        public async Task GenerateAsync(string operationType)
        {
            await WebAppGenerator.GeneratorCode(operationType);
      
            await Task.CompletedTask; // للتوافق مع async
        }
    }
}
