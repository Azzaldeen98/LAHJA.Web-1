using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Reflection;
using Castle.Components.DictionaryAdapter.Xml;
using AutoGenerator.Enums;
using System.Threading.Tasks;
using AutoGenerator.Attributes;
using AutoGenerator.CodeAnalysis.Attributes;

namespace AutoGenerator.Code.Service
{
    public class ServiceGenerator:BaseGenerator, ITGenerator
    {


        public static async Task GenerateServicesFromUseCaseTemplateAsync(GenerationOptions generationOptions)
        {

            if (!AutoCodeGenerator.CheckImportantInfo(generationOptions))
                return;


            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);


            string[] subfolders = Directory.GetDirectories(generationOptions.SourceDirectory);

            foreach (var folder in subfolders)
            {
                string folderName = new DirectoryInfo(folder).Name;
                Console.WriteLine($"📁 Folder: {folderName}");


                var output_directory = $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{folderName}";

                string[] files = Directory.GetFiles(folder);
                if (!files.Any())
                    continue;

                var new_class_name = $"{folderName}{generationOptions.DestinationCategoryName}";
                var new_interface_name = $"I{new_class_name}";

                var fildsPropertyCode = new StringBuilder().AppendLine();
                var parametersCode = new StringBuilder().AppendLine();
                var initializeFieldsCode = new StringBuilder().AppendLine();
                var methodsCode = new StringBuilder().AppendLine();
                var interfaceMethodsCode = new StringBuilder().AppendLine();

                foreach (var file in files)
                {

                    var code = File.ReadAllText(file);
                    var tree = CSharpSyntaxTree.ParseText(code);
                    var root = tree.GetCompilationUnitRoot();

                    var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                    foreach (var classDecl in classDeclarations)
                    {
                        bool isImplementsInterface = AutoCodeGenerator.IsImplementsOrInheritsBase(classDecl,
                                                    RoslynUtils.CreateSemanticModel(tree),
                                                    generationOptions.SourceBaseInterface);

                        if (isImplementsInterface)
                        {
                            var sourceClassName = classDecl.Identifier.Text;
                            if (!string.IsNullOrWhiteSpace(sourceClassName))
                            {
                                var variableName = $"{char.ToLower(sourceClassName[0])}{sourceClassName.Substring(1)}";
                                var fieldName = $"_{variableName}";
                                fildsPropertyCode.AppendLine($"     private readonly {sourceClassName} {fieldName};");
                                parametersCode.AppendLine($"            {sourceClassName} {variableName},");
                                initializeFieldsCode.AppendLine($"          {fieldName}={variableName};");

                                var newMethodName = sourceClassName.Replace(generationOptions.SourceCategoryName, "");
                                newMethodName = $"{char.ToLower(newMethodName[0])}{newMethodName.Substring(1)}Async";

                                var methods = classDecl.Members.OfType<MethodDeclarationSyntax>()
                                    .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));

                                foreach (var method in methods)
                                {


                                    if (generationOptions.ImplementGenerateInterface)
                                    {
                                        var interfaceMethodCode = AutoCodeGenerator.GenerateDeclarationMethod(method, newMethodName);
                                        if (!string.IsNullOrWhiteSpace(interfaceMethodCode))
                                        {
                                            interfaceMethodsCode.AppendLine(interfaceMethodCode);
                                            interfaceMethodsCode.AppendLine();
                                        }

                                    }

                                    var generateCodeMethod = GeneratedMethod(method, generationOptions.MethodContentCode
                                        .Replace("{PropertyFieldName}", fieldName), newMethodName);
                                    if (!string.IsNullOrWhiteSpace(generateCodeMethod))
                                    {
                                        methodsCode.AppendLine(generateCodeMethod);
                                        methodsCode.AppendLine();
                                    }


                                }

                            }
                        }
                    }
                }

                fildsPropertyCode.AppendLine();
                initializeFieldsCode.AppendLine();


                //// Generate the interface code

                var generateInterfaceCode = AutoCodeGenerator.GenerateInterface(new_interface_name,
                                                              generationOptions,
                                                              interfaces,
                                                              interfaceMethodsCode.ToString());
                parametersCode = parametersCode.Remove(parametersCode.Length - 1, 1);
                await GeneratorManager.SaveToFileAsync($"{output_directory}\\{new_interface_name}.cs", generateInterfaceCode);




                //// Generate the class code
                var generateClassCode = AutoCodeGenerator.GenerateClass(new_class_name,
                                                    new_interface_name,
                                                    generationOptions,
                                                    fildsPropertyCode.ToString(),
                                                    parametersCode.ToString(),
                                                    initializeFieldsCode.ToString(),
                                                    methodsCode.ToString());

                await GeneratorManager.SaveToFileAsync($"{output_directory}\\{new_class_name}.cs", generateClassCode);
            }
        }

        public static string GeneratedValidator(GenerationOptions generationOptions)
        {
            var model = generationOptions.ModelType;
            if (model == null) 
                return "";

            var classAttributes= TypeAttributesAnalyzer.GetClassAttributes(model);
            if(classAttributes!=null && classAttributes.Any(x=> x is ValidatorEnabledAttribute attrib && attrib.IsValidatorped))
            {
                foreach (var attribute in classAttributes)
                {
                    if (attribute is RegisterValidatorAttribute attrib)
                    {
                        //if (attrib.ValidatorType == ValidatorType.Api)
                        //{

                        //}
                            return "";


                    }
                }
            }
           


           
            
            return "";
        }
        public static string GeneratedMethod(MethodDeclarationSyntax method, string implementationCode, string newMethodName)
        {
            var sb = new StringBuilder();
            var returnType = method.ReturnType.ToString();
            var methodName = method.Identifier.Text;
            var parameters = string.Join(", ", method.ParameterList.Parameters
                .Select(p => $"{p.Type} {p.Identifier.Text}"));
            var variables = string.Join(", ", method.ParameterList.Parameters
                .Select(p => p.Identifier.Text));

            var modifiers = string.Join(" ", method.Modifiers.Select(m => m.Text));


            implementationCode = implementationCode.Replace("{InvokeMethodCallback}", $"{methodName}({variables})");
            implementationCode = implementationCode.Replace("[RETERN]", returnType.Contains("Task<") ? " return  " : "");


            if (string.IsNullOrWhiteSpace(newMethodName))
                return "";

            // كتابة توقيع الدالة + جسم فارغ
            sb.AppendLine($"    {modifiers} {returnType} {newMethodName}({parameters})");
            sb.AppendLine("    {");
            sb.AppendLine($"    {implementationCode}");
            sb.AppendLine("    }");
            sb.AppendLine();

            return AutoCodeGenerator.CleanGeneratorCode(sb.ToString());
        }




    }
}
