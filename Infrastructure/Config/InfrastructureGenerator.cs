using AutoGenerator.Code;
using Shared.Interfaces;
using Shared.Constants.ArchitecturalLayersRoot;
using Shared.Helpers;
using AutoGenerator.Config;
using System.Reflection;
using AutoGenerator.Code.Repository;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using AutoGenerator.AppFolder;
using AutoGenerator.CodeAnalysis.Injections;
using AutoGenerator.CodeAnalysis.Selectors;
using AutoGenerator.CodeAnalysis.Specifications;
using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Config
{
    public  class InfrastructureGenerator
    {
      

        private static string appRoot = ArchitecturalLayersRoot.InfrastructureRoot;
        private static string sourceFilePath = $"{ArchitecturalLayersRoot.InfrastructureRoot}\\DataSource\\ApiClientFactory\\Nswag\\WebClientApi.cs";
        public static async Task GeneratorCodeAsync()
        {


            await InterfaceInjectionClientTypesAsync();
            await InterfaceInjectionDtoModelsAsync();
            //await Task.Delay(1000);
            //await GenerateAllApiClientTemplates(sourceFilePath);
            //await Task.Delay(1000);
            await GeneratorRepositoriesForEntityModels();



            //await GenerateRepositoryTemplates();


        }
        /// <summary>
        /// Generates interface injections for client types in the specified assembly.
        /// </summary>
        /// <returns></returns>
        public static async Task InterfaceInjectionClientTypesAsync()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            var filter = new TypeSpecificationBuilder()
                       .InNamespace("Infrastructure.Nswag")
                       .IsClass(true)
                       .IsPublic(true)
                       .WhereNameEndWith("Client")
                       .Build();

            var clientTypes = new DataTypeExplorerService().GetDiscoveredTypes(assembly, filter);
            if (!clientTypes.Any())
            {
                //clientTypes = dataType.GetDataModelsType(assembly, "Infrastructure.Nswag").ToList();
                await CodeInjectionServiceFactory.CreateService(InjectionType.Interface).ExecuteAsync(new CodeInjectionOptions
                {
                    InjectionType = InjectionType.Interface,
                    IsSourceText = false,
                    SourceCodeOrFilePath = sourceFilePath,
                    OutputFilePath = sourceFilePath,
                    InterfaceFullName = "Shared.Interfaces.ITApiClient",
                    Selector = new TypeBasedClassSelector(clientTypes)
                });
            }
        }

        /// <summary>
        /// Generates interface injections for DTO models in the specified assembly.
        /// </summary>
        /// <returns></returns>
        public static async Task InterfaceInjectionDtoModelsAsync()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            IDataTypeExplorerService dataType = new DataTypeExplorerService();
            var typesModels = dataType.GetDataModelsType(assembly, typeof(ITDto), "Infrastructure.Nswag").ToList();
            if (!typesModels.Any())
            {
                typesModels = dataType.GetDataModelsType(assembly, "Infrastructure.Nswag").ToList();
                await CodeInjectionServiceFactory.CreateService(InjectionType.Interface).ExecuteAsync(new CodeInjectionOptions
                {
                    InjectionType = InjectionType.Interface,
                    IsSourceText = false,
                    SourceCodeOrFilePath = sourceFilePath,
                    OutputFilePath = sourceFilePath,
                    InterfaceFullName = "Shared.Interfaces.ITDto",
                    Selector = new TypeBasedClassSelector(typesModels)
                });
            }
        }
        /// <summary>
        /// Generates Repositories For Entity Models in the specified assembly.
        /// </summary>
        /// <returns></returns>
        public static async Task GeneratorRepositoriesForEntityModels()
        {
            //await GeneratorInterfacesRepository();
            //await Task.Delay(1000); // Wait for the interface generation to complete
            await GeneratorRepositoryImplementations();
            // Wait for the repository generation to complete
            //await EnsureAllRepositoryFilesExist();

            await ReBuildRepositoryMethodsBody();
            // Wait for the method body rewriting to complete

        }


        

        /// <summary>
        ///    Generates Interfaces Repositories For Entity Models in the specified assembly.
        /// </summary>
        /// <returns></returns>
        public static async Task GeneratorInterfacesRepository()
        {
          
          await  new RepositoryGenerator().GenerateIRepositories(new GenerationOptions
            {

                Assembly = ApplicationAssemblies.AssemblyDomain,
                DestinationRoot = $"{ArchitecturalLayersRoot.DomainRoot}",
                DestinationDirectory = "IRepositories\\",
                SourceType = typeof(ITDso),
                DestinationCategoryName = "Repository",
                NamespaceName = "Domain.IRepositories",
                Interfaces = new List<Type>
                    {
                           typeof(ITBaseRepository),
                           typeof(ITScope),
                    },
                Usings = new List<string>
                    {
                        "Shared.Interfaces",
                        "Shared.Wrapper",
                        "AutoGenerator.Attributes",
                        "Domain.Entity",
                        "AutoGenerator.Attributes",

                     },
                AdditionalCode = @"

            public {ClassName}({ApiClient} apiClient,IMapper mapper){
                _apiClient=apiClient;
                _mapper=mapper;

            }
                    ",
                MethodContentCode = @"",

            });
        }

        /// <summary>
        /// Generates Class Repositories by  Interfaces Repositories in the specified assembly.
        /// </summary>
        /// <returns></returns>
        public static async Task GeneratorRepositoryImplementations()
        {
            await new RepositoryGenerator().GenerateRepositoryImplementations(new GenerationOptions
            {

                SourceAssembly = ApplicationAssemblies.AssemblyDomain,
                Assembly = ApplicationAssemblies.AssemblyInfrastructure,
                DestinationRoot = $"{ArchitecturalLayersRoot.InfrastructureRoot}",
                DestinationDirectory = "Repositories",
                SourceType = typeof(ITBaseRepository),
                DestinationCategoryName = "Repository",
                NamespaceName = "Infrastructure.Repositories",

                Interfaces = new List<Type>
                {
                    //typeof(ITBaseRepository),
                },
                Usings = new List<string>
                    {

                        "Shared.Interfaces",
                        "Shared.Wrapper",
                        "AutoGenerator.Attributes",
                        "Domain.Entity",
                        "Infrastructure.Nswag",
                        "Domain.IRepositories",
                        "System.Threading.Tasks",
                        "Infrastructure.DataSource.ApiClient2",
                        "System.Collections.Generic",
                        "AutoMapper"


                     },
                AdditionalCode = @"

            public {ClassName}({ApiClient} apiClient,IMapper mapper){
                _apiClient=apiClient;
                _mapper=mapper;

            }
                    ",
                MethodContentCode = @"",

            });
        }

        /// <summary>
        /// Generates the content methods for class repository methods by entity models and  route to apiClient methods
        /// </summary>
        /// <returns></returns>
        public static async Task ReBuildRepositoryMethodsBody()
        {

            Assembly assembly = Assembly.GetExecutingAssembly();
            IDataTypeExplorerService dataType = new DataTypeExplorerService();

            var typesRepositories = dataType.GetRepositoriesType(assembly, "Repository", typeof(ITBaseRepository), "Infrastructure.Repositories").ToList();
            //var repo = typesRepositories.FirstOrDefault();
            foreach (var type in typesRepositories)
            {
                var filePath = $"{appRoot}\\Repositories\\{type.Name.Replace("Repository", "")}\\{type.Name}.cs";
                var code =await File.ReadAllTextAsync(filePath);
                var tree = CSharpSyntaxTree.ParseText(code);
                var root = tree.GetRoot();

                var generateCode = new RepositoryAnalyzer().ProcessRepository(type);

                //generateCode = generateCode.Select(entry => new KeyValuePair<string, string>(entry.Key, GeneratorHelpers.CleanMessyCode(entry.Value)))
                //    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                var rewriter = new MethodBodyRewriter(generateCode);
                var newRoot = rewriter.Visit(root);
  
                 newRoot = new RedundantBracesRemover().Visit(newRoot);
                var newCode = newRoot.NormalizeWhitespace().ToFullString();

          


                await File.WriteAllTextAsync(filePath, newCode);

            }

      
      
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static async Task GenerateRepositoryTemplates()
        {

            var files=FileScanner.GetAllCsFilePaths($"{appRoot}\\DataSource\\ApiClient2");
            foreach(var file in files)
            {
                //if(file.Contains("BaseApiClient") || file.Contains("IBuildApiClient"))
                //    continue;

               await GenerateAllRepositoryTemplates(file);
            }
            //if(files!=null && files.Any())
            //    GenerateAllRepositoryTemplates(files[0]);
        }

        /// <summary>
        ///  Generate ApiClients classes from NSwagger client classes
        /// </summary>
        /// <param name="sourceTemplateFilePath"></param>
        /// <returns></returns>
        public static async Task GenerateAllApiClientTemplates(string sourceTemplateFilePath)
        {
           await AutoCodeGenerator.GenerateAllClassTemplate(new GenerationOptions
            {

                SourceTemplateFilePath = sourceTemplateFilePath,
                DestinationRoot = $"{appRoot}",
                DestinationDirectory = "DataSource\\ApiClient2\\",
                BaseClass = "BuildApiClient<T>",
                SourceBaseInterface = "ITApiClient",
                SourceCategoryName = "Client",
                ImplementGenerateInterface = true,
                //ImplementInterfaces = true,
                DestinationCategoryName = "ApiClient",
                NamespaceName = "Infrastructure.DataSource.ApiClient2",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseApiClient)
                },
                Usings = new List<string>
                {
                    "System.Net.Http",
                    "System.Threading.Tasks",
                    "Infrastructure.Nswag",
                    "Infrastructure.Share.Invoker",
                     "AutoMapper",
                     "Shared.Interfaces",
                     "Infrastructure.DataSource.ApiClientBase",
                     "Infrastructure.DataSource.ApiClientFactory",
                     "Infrastructure.Share.Invoker",
                     "Microsoft.Extensions.Configuration",
                 },
                AdditionalCode = @"
  
    public {ClassName}(ClientFactory clientFactory, IMapper mapper,IApiInvoker apiInvoker) : base(clientFactory, mapper, apiInvoker){

    }
                ",
                MethodContentCode = @"
        [RETERN] await apiInvoker.InvokeAsync(async () => {
            var client = await GetApiClient();
            [RETERN]  await client.{InvokeMethodCallback};
        });
                ",

            });
        }

        /// <summary>
        /// Generates Class Repositories by  Interfaces Repositories by using direct Interfaces Repository in the specified assembly.
        /// </summary>
        /// <param name="sourceTemplateFilePath"></param>
        /// <returns></returns>
        public static async Task GenerateAllRepositoryTemplates(string sourceTemplateFilePath)
        {
           await AutoCodeGenerator.GenerateAllClassTemplate(new GenerationOptions
            {
                SourceTemplateFilePath = $"{sourceTemplateFilePath}",
                DestinationRoot = appRoot,
                DestinationDirectory = "Repositories",
                SourceBaseInterface = "ITBaseApiClient",
                SourceCategoryName = "ApiClient",
                ImplementGenerateInterface = true,
                //ImplementOtherInterfacesInClass = true,
                DestinationCategoryName = "Repository",
                NamespaceName = "Infrastructure.Repositories",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseRepository),
                    typeof(ITScope),
                },
                Usings = new List<string>
                {
                    "System.Net.Http",
                    "System.Threading.Tasks",
                    "Infrastructure.Nswag",
                    "Shared.Interfaces",
                     "Infrastructure.DataSource.ApiClientBase",
                     "Infrastructure.DataSource.ApiClient2",
                     "Microsoft.Extensions.Configuration",
        },
                AdditionalCode = @"
    private readonly {IPropertyType} _apiClient;
    public {ClassName}({IPropertyType} apiClient){
        _apiClient=apiClient;
    }
                ",
                MethodContentCode = @"
                
    [RETERN]  await _apiClient.{InvokeMethodCallback};
                ",

            });
        }

        //public static async Task EnsureAllRepositoryFilesExist()
        //{
        //    var basePath = Path.Combine(ArchitecturalLayersRoot.InfrastructureRoot, "Repositories");
        //    int retries = 5;

        //    while (retries-- > 0)
        //    {
        //        if (Directory.Exists(basePath) && Directory.GetFiles(basePath, "*.cs", SearchOption.AllDirectories).Length > 0)
        //        {
        //            return; // الملفات موجودة
        //        }

        //        await Task.Delay(1000); // انتظر ثانية وحاول مرة أخرى
        //    }

        //    throw new Exception("الملفات لم يتم إنشاؤها بعد انتهاء GeneratorRepositoryImplementations.");
        //}

    }
}
