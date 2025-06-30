using AutoGenerator.Code;
using Shared.Interfaces;
using Shared.Constants.ArchitecturalLayersRoot;
using Shared.Helpers;
using AutoGenerator.Helper;
using AutoGenerator.Code.Service;
using System.Threading.Tasks;


namespace Application.Config
{
    public  class ApplicationGenerator
    {
       
        private static string appRoot = ArchitecturalLayersRoot.ApplicationRoot;
        public static async Task GeneratorCodeAsync()
        {
            //await Task.Delay(1000);
            //await GenerateUseCaseTemplates();
            //await Task.Delay(1000);
            await GenerateServicesTemplates();
        }

        public static async Task GenerateUseCaseTemplates()
        {

            var files=FileScanner.GetAllCsFilePaths($"{ArchitecturalLayersRoot.DomainRoot}\\IRepositories");
            foreach (var file in files)
            {
                //if (file.StartsWith("I"))
                 await  GenerateAllUseCaseTemplates(file);
            }
            //if (files != null && files.Any())
            //    GenerateAllUseCaseTemplates(files[0]);
        }

        public static async Task GenerateServicesTemplates()
        {

            var files = FileScanner.GetAllCsFilePaths($"{appRoot}\\UseCases");
      
            if (files != null && files.Any())
            {
                 foreach (var file in files)
                {
                    string directoryPath = Path.GetDirectoryName(file); // المسار الكامل للمجلد الذي يحتوي على الملف
                    string lastFolderName = new DirectoryInfo(directoryPath).Name;
                    var typeEntityModel = GeneratorHelpers.FindTypeByClassNameAndNamespace(lastFolderName, "Domain.Entity");
                   await GenerateAllServicesTemplates(file, lastFolderName, typeEntityModel);
                }
             
            }
            
        }

        public static async Task GenerateAllUseCaseTemplates(string sourceTemplateFilePath)
        {
           await AutoCodeGenerator.GenerateUseCaseClassTemplate(new GenerationOptions
            {
                SourceTemplateFilePath = $"{sourceTemplateFilePath}",
                DestinationRoot = appRoot,
                DestinationDirectory = "UseCases",
                SourceBaseInterface = "ITBaseRepository",
                SourceCategoryName = "Repository",
                ImplementGenerateInterface = true,
                UnifiedNameForFunctions = "ExecuteAsync",
                BaseInterface = "ITBaseUseCase",
                SourceTypeIsClass = false,
                //ImplementOtherInterfacesInClass = true,
                DestinationCategoryName = "UseCase",
                NamespaceName = "Application.UseCases",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseUseCase),
                    typeof(ITScope),
                },
                Usings = new List<string>
                {
                    "System.Threading.Tasks",
                    "Shared.Interfaces",
                     "Microsoft.Extensions.Configuration",
                     "Domain.IRepositories",
                     "Shared.Wrapper",
                     "Domain.Entity",
        },
                AdditionalCode = @"
    private readonly {IPropertyType} _repository;
    public {ClassName}({IPropertyType} repository){
        _repository=repository;
    }

                ",
        MethodContentCode = @"
        [RETERN]  await _repository.{InvokeMethodCallback};
        ",

            });
        }
        public static async Task GenerateAllServicesTemplates(string sourceTemplateFilePath,string serviceRoot,Type? typeEntityModel)
        {
           await ServiceGenerator.GenerateServicesFromUseCaseTemplateAsync(new GenerationOptions
            {
                SourceTemplateFilePath = $"{sourceTemplateFilePath}",
                DestinationRoot = appRoot,
                ModelType=typeEntityModel,
                DestinationDirectory = "GenerateServices",
                SourceBaseInterface = "ITBaseUseCase",
                SourceCategoryName = "UseCase",
                SourceDirectory = $"{appRoot}\\UseCases",
                DestinationCategoryName = "Service",
                ImplementGenerateInterface = true,
                BaseInterface = "ITBaseShareService",
                NamespaceName = "Application.Services",
                Interfaces = new List<Type>
                {
                    typeof(ITBaseShareService),
                },
                Usings = new List<string>
                {
                    "System.Threading.Tasks",
                    "Shared.Interfaces",
                     "Microsoft.Extensions.Configuration",
                     "Application.UseCases",
                     "Shared.Wrapper",
                     "Domain.Entity",
                     "AutoGenerator.Attributes"
        },
                AdditionalCode = @"
                {PropertyFields}
            public {ClassName}(   {Parameters})
            {
                                {InitializeFields}
            }

                        ",
                MethodContentCode = @"

                    [RETERN] await {PropertyFieldName}.{InvokeMethodCallback};
                    ",

            });
        }
    }
}
