
using AutoGenerator.Helper;
using AutoMapper;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;
using System.Threading.Tasks;


namespace AutoGenerator.Code
{
    public class AutoGenerateUITemplateGenerator
    {

        public static string GenerateTemplateBuilder(
            GenerationOptions generationOptions, 
            ClassDeclarationSyntax classDecl, 
            string service_name,
            string builderType)
        {
            var sb = new StringBuilder();
            var generateCode = "";
            if (generationOptions.ImplementGenerateInterface)
            {

                generationOptions.InterfaceName = $"IBuilder{service_name}{builderType}<T>";
                generationOptions.BaseInterface = $"IBuilder{builderType}<T>";

                generateCode = AutoCodeGenerator.GenerateInterface(classDecl, generationOptions, null, false);
                sb.AppendLine(generateCode);
                sb.AppendLine();
                //SaveToFile($"{output_directory}\\{generationOptions.InterfaceName}.cs", generateCode);
     
                generationOptions.BaseInterface = $"IBuilder{service_name}{builderType}<E>";
            }


            //newGenerationOptions.AdditionalCode = @"";
            //newGenerationOptions.MethodContentCode = "";
            generationOptions.ClassName = $"Builder{service_name}{builderType}<T,E>";
            generateCode = AutoCodeGenerator.GenerateClass(classDecl, generationOptions, sourceClassName: "", false, "abstract", "abstract");
            sb.AppendLine(generateCode);
            sb.AppendLine();

            return sb.ToString();
        }
        public static string GenerateTemplateBuilderComponents(
            GenerationOptions generationOptions,
            ClassDeclarationSyntax classDecl,
            string service_name,
            string nameStartWith= "Builder",
            string typeClass= "interface",
            string baseClass= "IBuilderComponents<T>",
            string genericType= "<T>")
        {
            var sb = new StringBuilder();
      

            var methods = classDecl.Members
                           .OfType<MethodDeclarationSyntax>()
                           .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));


            
            sb.AppendLine();
            sb.Append($"public {typeClass} {nameStartWith}{service_name}Components{genericType} : {baseClass}");
            sb.AppendLine("{");

         
          
   
            foreach (var method in methods)
            {
                var generateCode = GenerateDeclarationDelegate(method.Identifier.Text, "public", "Func<T, Task>", "Submit");
                sb.AppendLine(generateCode);
            }

            sb.AppendLine("}");
 
            sb.AppendLine();


               
         

            return sb.ToString();
        }

        public static string GenerateDeclarationDelegate(
            string methodName,
              string typeModifier = "public",
            string returnType = "Func<T, Task>", 
            string nameStartWith = "")
        {

            methodName =  methodName.Replace("Async","");
            methodName= methodName.First().ToString().ToUpper() + methodName.Substring(1);


            return $"  {typeModifier} {returnType} {nameStartWith}{methodName}{{get;set;}}";

   
        }



      
        public static string TemplateShareClassCode(string service_name, string baseClass = "TemplateBase<T,E>")
        {


          return @$"public class Template{service_name}Share<T,E> : {baseClass}
            {{
                public IBuilder{service_name}Components<E> BuilderComponents {{ get => builderComponents; }}
                protected IBuilder{service_name}Api<E> builderApi;

                protected readonly IShareTemplateProvider shareProvider;
                protected readonly CustomAuthenticationStateProvider AuthStateProvider;

                private readonly IBuilder{service_name}Components<E> builderComponents;

                public Template{service_name}Share(
                        CustomAuthenticationStateProvider authStateProvider,
                        LAHJA.Helpers.Services.AuthService authService,
                        T client,
                        IBuilder{service_name}Components<E> builderComponents,
                        IShareTemplateProvider shareProvider) : base(shareProvider.Mapper, authService, client)
                {{



                    builderComponents = new Builder{service_name}Components<E>();
                    this.builderComponents = builderComponents;
                    AuthStateProvider = authStateProvider;
                    this.shareProvider = shareProvider;
                }}

        }}";


   
        }

        public static string GenerateBuilderApiClientClass(
       GenerationOptions generationOptions,
       ClassDeclarationSyntax classDecl,
       string serviceName,
         SemanticModel semanticModel)
        {
            var sb = new StringBuilder();

            // Header and constructor
            sb.AppendLine($@"
public class Builder{serviceName}ApiClient : Builder{serviceName}Api<Application.Services.{serviceName}Service, DataBuild{serviceName}Base>, 
      IBuilder{serviceName}Api<DataBuild{serviceName}Base>
{{
    public Builder{serviceName}ApiClient(IMapper mapper, Application.Services.{serviceName}Service service) 
        : base(mapper, service)
    {{
    }}
");

            var methods = classDecl.Members
                .OfType<MethodDeclarationSyntax>()
                .Where(m => m.Modifiers.Any(SyntaxKind.PublicKeyword));

            foreach (var method in methods)
            {
                var methodName = method.Identifier.Text;
                var returnType = method.ReturnType.ToString();
                var parameters = method.ParameterList.Parameters;

                var parameters_text = string.Join(", ", method.ParameterList.Parameters.Select(p => $"{p.Type} {p.Identifier.Text}"));
                var variables = string.Join(", ", method.ParameterList.Parameters.Select(p => p.Identifier.Text));

                var mappedTypeName = methodName;// GetMappedTypeName(methodName); // <-- تحتاج لتحديد قاعدة التسمية
               


                sb.AppendLine($@"
    public override  async {returnType} {methodName}(DataBuild{serviceName}Base data,CancellationToken cancellationToken)
    {{ ");


                var simpleTypes = new[] { "string", "bool", "int", "float", "string?", "bool?", "int?", "float?" };

                if (parameters != null && parameters.Any())
                {
                    var parametersExcludingLast = parameters.Take(parameters.Count - 1);
                    foreach (var param in parametersExcludingLast) 
                    {
                        var methodBody = "";


                        //var typeInfo = semanticModel.GetTypeInfo(param.Type);
                        //var typeSymbol = typeInfo.Type;

                        if (!simpleTypes.Contains(param.Type.ToString()))
                        {

                            methodBody = @$"        var {param.Identifier.Text}= Mapper.Map<{param.Type}>(data);";

                        }
                        else
                        {
                            var name = param.Identifier.Text;
                            if (!string.IsNullOrEmpty(name))
                            {
                                var capitalized = char.ToUpper(name[0]) + name.Substring(1);
                                methodBody = $"         var {param.Identifier.Text} = data.{capitalized};";
                            }
                           
                        }
                        sb.AppendLine(methodBody);
                    }
                    
        
                }
     
                var call = returnType.Contains("Task<") ? " return  " : "";
    
                sb.AppendLine($"        {call} await Service.{methodName}({variables}); ");
                sb.AppendLine();
                sb.AppendLine("    }");
            }

            sb.AppendLine("}"); // close class

            return sb.ToString();
        }

        public static async Task GenerateAllUITemplatesClass(GenerationOptions generationOptions)
        {


            if (!AutoCodeGenerator.CheckImportantInfo(generationOptions))
                return;

            var sb = new StringBuilder();


            var code = File.ReadAllText(generationOptions.SourceTemplateFilePath);
            var tree = CSharpSyntaxTree.ParseText(code);
            var root = tree.GetCompilationUnitRoot();
            var classDeclarations = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

            // توليد compilation يدويًا
            var compilation = CSharpCompilation.Create(
                "GeneratedCode",
                new[] { tree },
                new[] {
                        MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                        MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
                        MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location),
                        MetadataReference.CreateFromFile(typeof(IMapper).Assembly.Location), // لو كنت تستخدم AutoMapper
                        MetadataReference.CreateFromFile(typeof(Task).Assembly.Location)
                },
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
            );

            // استخدم semanticModel
            var semanticModel = compilation.GetSemanticModel(tree);

            List<Type> interfaces = new List<Type>();
            if (generationOptions.Interfaces.Any())
                interfaces.AddRange(generationOptions.Interfaces);

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
                        var service_name = sourceClassName.Replace(generationOptions.SourceCategoryName, "");

                        //generationOptions.BaseIClassName = baseClassName;
                        //var output_directory = "";

                        if (!string.IsNullOrWhiteSpace(service_name))
                        {

                            generationOptions.NamespaceName = generationOptions.NamespaceName.Replace("{ServiceName}", service_name);
                            sb.Append(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));
                            sb.AppendLine();


                            generationOptions.ClassName = $"{generationOptions.DestinationCategoryName}{service_name}";
                            var output_file = $"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{service_name}\\{generationOptions.ClassName}.cs";

                  
                            var newGenerationOptions = generationOptions.Clone();
                            generationOptions.BaseClass = "BuilderApi<T,E>";
                            var generateCode = GenerateTemplateBuilder(generationOptions, classDecl, service_name,"Api");
                            sb.AppendLine(generateCode);
                            sb.AppendLine();
                         

                            generateCode=GenerateTemplateBuilderComponents(generationOptions,
                                classDecl,
                                service_name,
                                "IBuilder",
                                "interface", 
                                "IBuilderComponents<T>", 
                                "<T>");

                            sb.AppendLine(generateCode);
                            sb.AppendLine();

                            generateCode = GenerateTemplateBuilderComponents(generationOptions, 
                                classDecl, 
                                service_name,
                                "Builder",
                                "class", 
                                $"IBuilder{service_name}Components<T>", 
                                "<T>");

                            sb.AppendLine(generateCode);
                            sb.AppendLine();           
                            
                            generateCode = TemplateShareClassCode(service_name);

                            sb.AppendLine(generateCode);
                            sb.AppendLine();             
                            
                            generateCode = GenerateBuilderApiClientClass(generationOptions, classDecl, service_name, semanticModel);

                            sb.AppendLine(generateCode);
                            sb.AppendLine();

                            await GeneratorManager.SaveToFileAsync(output_file, sb.ToString());

                        }


                    }
                }
            }

        }
    }
    
}
