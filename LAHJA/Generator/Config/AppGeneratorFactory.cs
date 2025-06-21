using AutoGenerator.Interfaces;


namespace LAHJA.Generator.Config
{
    public static class AppGeneratorFactory
    {
        public static IAppGenerator Create(string type)
        {
            return type switch
            {
                "Infrastructure" => new InfrastructureAppGenerator(),
                "Application" => new ApplicationAppGenerator(),
                "Web" => new WebAppGeneratorWrapper(),
                _ => throw new ArgumentException("Unknown generator type")
            };
        }
    }
}
