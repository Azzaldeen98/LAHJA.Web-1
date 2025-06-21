using System.Reflection;

namespace AutoGenerator.Code;

public class GenerationOptions
{
    public Assembly SourceAssembly { get; set; }
    public Assembly Assembly { get; set; }
    public bool SourceTypeIsClass { get; set; }
    public string ClassName { get; set; }
    public string InterfaceName { get; set; }
    public string SourceBaseInterface { get; set; }
    public string BaseInterface { get; set; }

    public string UnifiedNameForFunctions { get; set; }

    public bool ImplementGenerateInterface { get; set; } = false;
    public bool ImplementOtherInterfacesInClass { get; set; } = false;
    public string SourceTemplateFilePath { get; set; }
    public string SourceCategoryName { get; set; }
    public string DestinationRoot { get; set; }
    public string DestinationDirectory { get; set; }
    public string SourceDirectory { get; set; }
    public string DestinationCategoryName { get; set; }
    public Type SourceType { get; set; }
    public Type? ModelType { get; set; }
    public string NamespaceName { get; set; } = "GeneratedClasses";
    public string AdditionalCode { get; set; } = "";
    public string MethodContentCode { get; set; } = "";
    public List<Type> Interfaces { get; set; } = new List<Type>();

    public PropertyInfo[] Properties { get; set; }

    public GenerationOptions() { }

    public GenerationOptions(string className,Type sourceType,bool isProperties=true)
    {
        ClassName = className;
        SourceType = sourceType;
        if(isProperties)
             Properties = sourceType.GetProperties();

    }

    public GenerationOptions(string baseClass,
        string sourceTemplateFilePath,
        string destinationRoot,
        string sourceCategoryName,
        string destinationCategoryName)
    {
        SourceTemplateFilePath = sourceTemplateFilePath;
        BaseClass = baseClass;
        DestinationRoot = destinationRoot;
        DestinationCategoryName = destinationCategoryName;
        
    }

    public List<string> Usings { get; set; } = new List<string>();
    public string BaseClass { get; set; } = null;
    public string Template { get; set; } = @"
public class {ClassName} {BaseClass} {Interfaces}
{
    {Properties}
    {AdditionalCode}
}
    ";

    public string ITemplate { get; set; } = @"
public interface {InterfaceName} {ImplementInterfaces}
{
    {DeclareMethods}
}
    ";


    public GenerationOptions Clone()
    {
        return new GenerationOptions
        {
            ClassName = this.ClassName,
            Assembly=this.Assembly,
            SourceAssembly = this.SourceAssembly,
            InterfaceName = this.InterfaceName,
            SourceBaseInterface = this.SourceBaseInterface,
            BaseInterface = this.BaseInterface,
            UnifiedNameForFunctions = this.UnifiedNameForFunctions,
            ImplementGenerateInterface = this.ImplementGenerateInterface,
            ImplementOtherInterfacesInClass = this.ImplementOtherInterfacesInClass,
            SourceTemplateFilePath = this.SourceTemplateFilePath,
            SourceCategoryName = this.SourceCategoryName,
            DestinationRoot = this.DestinationRoot,
            DestinationDirectory = this.DestinationDirectory,
            SourceDirectory = this.SourceDirectory,
            DestinationCategoryName = this.DestinationCategoryName,
            NamespaceName = this.NamespaceName,
            AdditionalCode = this.AdditionalCode,
            MethodContentCode = this.MethodContentCode,
            Usings = new List<string>(this.Usings),
            Interfaces = new List<Type>(this.Interfaces),
            BaseClass = this.BaseClass,
            Template = this.Template,
            Properties = this.Properties?.ToArray(),  // Clone array
                                                      // ملاحظة: SourceType من نوع Type وهو immutable، لا داعي لاستنساخه
        };
    }

}
