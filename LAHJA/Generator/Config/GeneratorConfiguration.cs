namespace LAHJA.Generator.Config
{
    public static class GeneratorConfiguration
    {
        public static List<string> GetGeneratorsFromConfig()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // أو مسار المشروع
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var generators = configuration.GetSection("GeneratorsToRun").Get<List<string>>();
            return generators ?? new List<string>();
        }
    }



}
