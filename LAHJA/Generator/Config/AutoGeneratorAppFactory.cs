using AutoGenerator.Interfaces;


namespace LAHJA.Generator.Config
{
    public static class AutoGeneratorAppFactory
    {
      private  static List<IAppGenerator> generators = new List<IAppGenerator>();

        private static ILogger buildLogger=LoggerFactory.Create(builder =>builder.AddConsole()).CreateLogger("ServiceRegistrationLogger");
      
        public static async Task<IAppGenerator> GenerateAsync(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                buildLogger.LogError("No generator name provided. Please specify a generator name.");
                return null;
            }

            try 
            {

                if(generators.Any(g => g.GetType().Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    buildLogger.LogInformation($"Generator for layer {name} already exists. Skipping creation.");
                    return generators.First(g => g.GetType().Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                }

                var generator= AppGeneratorFactory.Create(name);
                if(generator == null)
                {
                    buildLogger.LogError($"No generator found for name: {name}");
                    return null;
                }
                else
                {
                    buildLogger.LogInformation($"Successfully created generator for layer: {name}");
                    generators.Add(generator);
                    await generator.GenerateAsync();
                    return generator;
                }

            }
            catch (Exception ex)
            {
                buildLogger.LogError(ex, $"Error when generated : {name}");
                Console.WriteLine($"Error when generated - ({name}): {ex.Message}");

                return null;
            }

}
        public static async Task GenerateAllAsync()
        {
            buildLogger.LogInformation("Read  Generating Apps From app settings");
            var generatorTypes = GeneratorConfiguration.GetGeneratorsFromConfig();

     
        
    
            foreach (var type in generatorTypes)
            {

                if (string.IsNullOrWhiteSpace(type))
                {
                    buildLogger.LogError("No generator type provided. Please specify a generator type.");
                    continue;
                }
               await GenerateAsync(type);

                //try
                //{
                //    buildLogger.LogInformation($"Start Generating code for layer: {type}");
                //    var generator = AppGeneratorFactory.Create(type);
                //    generators.Add(generator);
                //    buildLogger.LogInformation($"Successfully created generator for layer: {type}");
                //}
                //catch (Exception ex)
                //{
                //    buildLogger.LogError(ex, $"Error when generated : {type}");
                //    Console.WriteLine($"Error when generated - ({type}): {ex.Message}");
            
            }

            //foreach (var generator in generators)
            //{
            //    await generator.GenerateAsync();
            //}

            buildLogger.LogInformation("End Generating code for all layers ");
        }
    }
}
