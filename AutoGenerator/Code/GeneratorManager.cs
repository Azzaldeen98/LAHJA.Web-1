using System.Text;
using System.Threading.Tasks;

namespace AutoGenerator.Code;

public class GeneratorManager
{
    private Dictionary<string, ITGenerator> generators = new Dictionary<string, ITGenerator>();

    
    public void RegisterGenerator(string generatorName, ITGenerator generator)
    {
        generators[generatorName] = generator;
    }

    public ITGenerator GetGenerator(string generatorName)
    {
        if (generators.TryGetValue(generatorName, out ITGenerator generator))
        {
            return generator;
        }
        else
        {
            return null; // أو يمكنك طرح استثناء
        }
    }

    public string GenerateCode(string generatorName, GenerationOptions options)
    {
        ITGenerator generator = GetGenerator(generatorName);
        if (generator != null)
        {
            return generator.Generate(options);
        }
        else
        {
            return null; // أو يمكنك طرح استثناء
        }
    }

    public async Task SaveCodeToFile(string generatorName, string filePath, GenerationOptions options)
    {
        ITGenerator generator = GetGenerator(generatorName);
        if (generator != null)
        {
            string generatedCode = generator.Generate(options);
            if (!string.IsNullOrEmpty(generatedCode))
            {
              await  File.WriteAllTextAsync(filePath, generatedCode);
                Console.WriteLine($"Generated code saved to {filePath}");
            }
            else
            {
                Console.WriteLine("No generated code to save.");
            }
        }
    }

    public static async Task SaveToFileAsync(string filePath, string content)
    {
        try
        {

            var directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory))
            {
                Directory.CreateDirectory(directory);
            }
           await File.WriteAllTextAsync(filePath, content, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"حدث خطأ أثناء حفظ الملف: {ex.Message}");
        }
    }
}
