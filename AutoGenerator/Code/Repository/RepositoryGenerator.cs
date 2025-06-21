using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using AutoGenerator.AppFolder;
using AutoGenerator.Helper;
using Shared.Constants.ArchitecturalLayersRoot;
using Shared.Interfaces;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenerator.Code.Repository
{
    public class RepositoryGenerator:BaseGenerator, ITGenerator
    {

        public new string Generate(GenerationOptions options)
        {

            string generatedCode = base.Generate(options);
            return generatedCode;

        }
        public async Task GenerateIRepositories(GenerationOptions generationOptions)
        {
            var modelTypes = generationOptions.Assembly.GetTypes()
                .Where(t => generationOptions.SourceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .ToList();



            foreach (var model in modelTypes)
            {

                var hasTranslate = model != null && model.IsDefined(typeof(HasTranslateAttribute));

                var modelName = model.Name;
                var autoGenAttr = model.GetCustomAttribute<AutoGenerateAttribute>();
                var supportedAttr = model.GetCustomAttribute<SupportedMethodsAttribute>();
                var autoMapper = model.GetCustomAttribute<AutomateMapperAttribute>();
         

                if (autoGenAttr != null && autoGenAttr.GenerateTarget.HasFlag(GenerationTarget.Repository))
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));


                    var class_name = $"I{modelName}{generationOptions.DestinationCategoryName}";
                    var code = generationOptions.ITemplate.Replace("{InterfaceName}", $"{class_name}:")
                    .Replace("{ImplementInterfaces}", string.Join(",", generationOptions.Interfaces.Select(x => x.Name)));



                    sb.AppendLine(code);
                    sb.AppendLine();


                    var flags = Enum.GetValues(typeof(SupportedMethods)).Cast<SupportedMethods>();
                    var scode = new StringBuilder();
                    //foreach (var flag in flags)
                    {
                        if (!flags.Any())
                            continue;

                        var hasCRUD = supportedAttr.Methods.HasFlag(SupportedMethods.CRUD);
                        var hasREAD = supportedAttr.Methods.HasFlag(SupportedMethods.READ);
                        var hasCUGET = autoMapper.Methods.HasFlag(SupportedMethods.CUGET);
                        var hasRRPC = autoMapper.Methods.HasFlag(SupportedMethods.RRPC);

                        //var flagText = flag.ToString();
                        var declerMethod = "";
                        var transParamater = hasTranslate?"string lg,":"";

                        // GetAllWithPaged
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.GetAllWithPaged))
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: $"GetAll{modelName}sAsync",
                                modelName: modelName,
                                returnType: $"PaginatedResult<{modelName}>",
                                methodFlag: SupportedMethods.GetAllWithPaged,
                                autoMapper: autoMapper,
                                hasREAD: hasREAD,
                                customParams: "",
                                includeLangParam: hasTranslate
                            );
                        }

                        // GetAll or READ
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.GetAll) || hasREAD)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: $"Get{modelName}sAsync",
                                modelName: modelName,
                                returnType: $"ICollection<{modelName}>",
                                methodFlag: SupportedMethods.GetAll,
                                autoMapper: autoMapper,
                                hasREAD: hasREAD,
                                customParams: "",
                                includeLangParam: hasTranslate
                            );
                        }
                        // GetCurrent
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.GetCurrent) || hasREAD)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: $"Get{modelName}Async",
                                modelName: modelName,
                                returnType: $"{modelName}",
                                methodFlag: SupportedMethods.GetCurrent,
                                autoMapper: autoMapper,
                                hasREAD: hasREAD,
                                customParams: "",
                                includeLangParam: hasTranslate
                            );
                        }
                        // CountAll
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.CountAll))
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: $"CountAll{modelName}sAsync",
                                modelName: modelName,
                                returnType: "int",
                                methodFlag: SupportedMethods.CountAll,
                                autoMapper: null,
                                hasREAD: false,
                                customParams: "",
                                includeLangParam: false
                            );
                        }

                        // GetById or GetOne or READ
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.GetById)
                            || supportedAttr.Methods.HasFlag(SupportedMethods.GetOne)
                            || hasREAD)
                        {
                            var isGetOne = supportedAttr.Methods.HasFlag(SupportedMethods.GetOne);
                            string methodName = isGetOne ? "GetOneAsync" : "GetByIdAsync";

                            declerMethod += GenerateMethodSignature(
                                methodName: methodName,
                                modelName: modelName,
                                returnType: modelName,
                                methodFlag: isGetOne ? SupportedMethods.GetOne: SupportedMethods.GetById, // أو يمكن تعديلها لتدعم GetOne أيضاً حسب الدالة
                                autoMapper: autoMapper,
                                hasREAD: hasCUGET,
                                customParams: "string id,",
                                includeLangParam: hasTranslate
                            );
                        }


                        // Create or CRUD
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.Create) || hasCRUD)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: "CreateAsync",
                                modelName: modelName,
                                returnType: modelName,
                                methodFlag: SupportedMethods.Create,
                                autoMapper: autoMapper,
                                hasREAD: true,
                                customParams: $"{modelName} model,",
                                includeLangParam: false
                            );
                        }

                        // Update or CRUD
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.Update) || hasCRUD)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: "UpdateAsync",
                                modelName: modelName,
                                returnType: modelName,
                                methodFlag: SupportedMethods.Update,
                                autoMapper: autoMapper,
                                hasREAD: true,
                                customParams: $"{modelName} model,",
                                includeLangParam: false
                            );
                        }

                        // Delete or CRUD
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.Delete) || hasCRUD)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: "DeleteAsync",
                                modelName: modelName,
                                returnType: "",
                                methodFlag: SupportedMethods.Delete,
                                autoMapper: null,
                                hasREAD: false,
                                customParams: "string id,",
                                includeLangParam: false
                            );
                        }


                        // Pause, Renew, Resume, Cancel مع hasRRPC
                        if (supportedAttr.Methods.HasFlag(SupportedMethods.Pause) || hasRRPC)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: "PauseAsync",
                                modelName: modelName,
                                returnType: "",
                                methodFlag: SupportedMethods.Pause,
                                autoMapper: null,
                                hasREAD: false,
                                customParams: $"string id,{modelName} model",
                                includeLangParam: false
                            );
                        }

                        if (supportedAttr.Methods.HasFlag(SupportedMethods.Renew) || hasRRPC)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: "RenewAsync",
                                modelName: modelName,
                                returnType: "",
                                methodFlag: SupportedMethods.Renew,
                                autoMapper: null,
                                hasREAD: false,
                                customParams: "string id,",
                                includeLangParam: false
                            );
                        }

                        if (supportedAttr.Methods.HasFlag(SupportedMethods.Resume) || hasRRPC)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: "ResumeAsync",
                                modelName: modelName,
                                returnType: "",
                                methodFlag: SupportedMethods.Resume,
                                autoMapper: null,
                                hasREAD: false,
                                customParams: "string id,",
                                includeLangParam: false
                            );
                        }

                        if (supportedAttr.Methods.HasFlag(SupportedMethods.Cancel) || hasRRPC)
                        {
                            declerMethod += GenerateMethodSignature(
                                methodName: "CancelAsync",
                                modelName: modelName,
                                returnType: "",
                                methodFlag: SupportedMethods.Cancel,
                                autoMapper: null,
                                hasREAD: false,
                                customParams: "string id,",
                                includeLangParam: false
                            );
                        }


                        /// الكود  السابق
                        {
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.GetAllWithPaged) )
                            //{
                            //    if (autoMapper?.Methods.HasFlag(SupportedMethods.GetAllWithPaged) == true || hasCUGET)
                            //        declerMethod += $"[AutomateMapper]\n";

                            //    declerMethod += $"public Task<PaginatedResult<{modelName}>> GetAll{modelName}sAsync({transParamater}CancellationToken cancellationToken);\n";
                            //}
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.GetAll) || hasREAD)
                            //{
                            //    if (autoMapper?.Methods.HasFlag(SupportedMethods.GetAll) == true || hasCUGET)
                            //        declerMethod += $"[AutomateMapper]\n";

                            //    declerMethod += $"\tpublic Task<ICollection<{modelName}>> Get{modelName}sAsync({transParamater}CancellationToken cancellationToken);\n";
                            //}
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.CountAll) )
                            //{
                            //    declerMethod += $"\tpublic Task<int> CountAll{modelName}sAsync(CancellationToken cancellationToken);\n";
                            //}
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.GetById) ||supportedAttr.Methods.HasFlag(SupportedMethods.GetOne)  || hasREAD)
                            //{
                            //    // تحديد اسم الميثود المناسب
                            //    string methodName = supportedAttr.Methods.HasFlag(SupportedMethods.GetOne) ? "GetOneAsync" : "GetByIdAsync";

                            //    // التحقق من المابنق
                            //    if (autoMapper?.Methods.HasFlag(SupportedMethods.GetById) == true ||
                            //        autoMapper?.Methods.HasFlag(SupportedMethods.GetOne) == true ||
                            //        hasCUGET)
                            //    {
                            //        declerMethod += $"[AutomateMapper]\n";
                            //    }

                            //    declerMethod += $"\tpublic Task<{modelName}> {methodName}(string id,{transParamater}CancellationToken cancellationToken);\n";
                            //}



                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.Update) || hasCRUD )
                            //{
                            //    if (autoMapper?.Methods.HasFlag(SupportedMethods.Update) == true || hasCUGET)
                            //        declerMethod += $"[AutomateMapper]\n";

                            //    declerMethod += $"\tpublic Task<{modelName}> UpdateAsync({modelName} model,CancellationToken cancellationToken);\n";
                            //}
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.Delete) || hasCRUD )
                            //{
                            //    declerMethod += $"\tpublic Task DeleteAsync(string id,CancellationToken cancellationToken);\n";
                            //}

                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.Pause) || hasRRPC)
                            //{
                            //    declerMethod += $"\tpublic Task PauseAsync(string id,CancellationToken cancellationToken);\n";
                            //}
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.Renew) || hasRRPC)
                            //{
                            //    declerMethod += $"\tpublic Task RenewAsync(string id,CancellationToken cancellationToken);\n";
                            //}
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.Resume) || hasRRPC)
                            //{
                            //    declerMethod += $"\tpublic Task ResumeAsync(string id,CancellationToken cancellationToken);\n";
                            //}  
                            //if (supportedAttr.Methods.HasFlag(SupportedMethods.Cancel) || hasRRPC)
                            //{
                            //    declerMethod += $"\tpublic Task CancelAsync(string id,CancellationToken cancellationToken);\n";
                            //}
                            }



                            scode.AppendLine(declerMethod);

                    }

                    sb.Replace("{DeclareMethods}", scode.ToString());

                    //sb.AppendLine("}");
                    await GeneratorManager.SaveToFileAsync(@$"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{modelName}\\{class_name}.cs", sb.ToString());




                }
            }

        }
        private static bool ShouldAddMapper(SupportedMethods method, AutomateMapperAttribute mapperAttr, bool hasCUGET)
        {
            return (mapperAttr?.Methods.HasFlag(method) == true) || hasCUGET;
        }
        // افترض أن هذه الدالة معرفة مسبقاً
        string GenerateMethodSignature(
            string methodName,
            string modelName,
            string returnType,
            SupportedMethods methodFlag,
            AutomateMapperAttribute autoMapper,
            bool hasREAD,
            string customParams = "",
            bool includeLangParam = false,
            bool endWithSemicolon = true)
        {
            var sb = new StringBuilder();

            bool useMapper = autoMapper != null && (autoMapper.Methods.HasFlag(methodFlag) || hasREAD);
            if (useMapper)
                sb.AppendLine("\t[AutomateMapper]");

            string parameters = customParams;
            if (includeLangParam)
            {
                if (!string.IsNullOrEmpty(parameters))
                    parameters = "string lg, " + parameters.Trim().TrimEnd(',')+ ",CancellationToken cancellationToken";
                else
                    parameters = "string lg, CancellationToken cancellationToken";
            }
            else if (string.IsNullOrEmpty(parameters))
            {
                parameters = "CancellationToken cancellationToken";
            }
            else
            {
                parameters = parameters.Trim().TrimEnd(',') + ", CancellationToken cancellationToken";
            }
            returnType = string.IsNullOrWhiteSpace(returnType) ? "Task" : $"Task<{returnType}>";
            string signature = $"\tpublic {returnType} {methodName}({parameters})";
            if (endWithSemicolon)
                signature += ";";

            sb.AppendLine(signature);

            return sb.ToString();
        }





        public async Task GenerateRepositoryImplementations(GenerationOptions generationOptions)
        {
            var dist_root = generationOptions.DestinationRoot;

            var interfaces = generationOptions.SourceAssembly
                .GetTypes()
                .Where(t => t.IsInterface &&
                           generationOptions.SourceType.IsAssignableFrom(t) &&
                            t != generationOptions.SourceType) // استبعاد الواجهة الأصلية نفسها
                .ToList();

            //var code=generationOptions.Template.Replace("{ClassName}", $"{class_name}:")
            //    .Replace("{BaseClass}","")
            //    .Replace("{Interfaces}", string.Join(",", generationOptions.Interfaces.Select(x=>x.Name)))
            //    .Replace("{Properties}", 
            //    @$"private readonly I{model.Name}ApiClient _apiClient;
            //    private readonly IMapper _mapper;
            //");
            //var tasks = new List<Task>(); // تجميع المهام

            foreach (var iRepo in interfaces)
            {
               await GenerateAndSave(iRepo, generationOptions); // اجمع المهام هنا
            }

            //await Task.WhenAll(tasks);
            
        }
        private async Task GenerateAndSave(Type iRepo, GenerationOptions generationOptions)
        {
            var modelName = iRepo.Name.Replace(generationOptions.DestinationCategoryName, "").Replace("I", "");
            var className = $"{modelName}{generationOptions.DestinationCategoryName}";
            var interfaceName = iRepo.Name;
            var sb = new StringBuilder();

            sb.AppendLine(GeneratorHelpers.GenerateUsingsNamespaces(generationOptions));
            sb.AppendLine();

            sb.AppendLine($"\tpublic partial class {className} : {interfaceName}");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\tprivate readonly I{modelName}ApiClient _apiClient;");
            sb.AppendLine("\t\tprivate readonly IMapper _mapper;");
            sb.AppendLine();
            sb.AppendLine($"\t\tpublic {className}(I{modelName}ApiClient apiClient, IMapper mapper)");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\t_apiClient = apiClient;");
            sb.AppendLine("\t\t\t_mapper = mapper;");
            sb.AppendLine("\t\t}");
            sb.AppendLine();

            foreach (var method in iRepo.GetMethods())
            {
                var methodSyntax = GeneratorHelpers.ConvertToSyntax(method);
                (var returnType, var modifiers) = AutoCodeGenerator.CleanMethodSignature(methodSyntax);

                returnType = !returnType.Contains("async") ? $"async {returnType}" : returnType;

                var paramList = string.Join(",", method.GetParameters().Select(p => $"{p.ParameterType.Name} {p.Name}"));
                sb.AppendLine($"\t\t{modifiers} {returnType} {method.Name}({paramList})");
                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                sb.AppendLine("\t\t}");
                sb.AppendLine();
            }

            sb.AppendLine("\t}");

            var filePath = @$"{generationOptions.DestinationRoot}\\{generationOptions.DestinationDirectory}\\{modelName}\\{className}.cs";
            await GeneratorManager.SaveToFileAsync(filePath, sb.ToString());
        }

        public async Task GenerateRepositoryImplementations2(GenerationOptions generationOptions)
        {
            var dist_root = ArchitecturalLayersRoot.InfrastructureRoot;

            var interfaces = ApplicationAssemblies.AssemblyDomain
                .GetTypes()
                .Where(t => t.IsInterface &&
                            typeof(ITBaseRepository).IsAssignableFrom(t) &&
                            t != typeof(ITBaseRepository)) // استبعاد الواجهة الأصلية نفسها
                .ToList();

            //var code=generationOptions.Template.Replace("{ClassName}", $"{class_name}:")
            //    .Replace("{BaseClass}","")
            //    .Replace("{Interfaces}", string.Join(",", generationOptions.Interfaces.Select(x=>x.Name)))
            //    .Replace("{Properties}", 
            //    @$"private readonly I{model.Name}ApiClient _apiClient;
            //    private readonly IMapper _mapper;
            //");

            foreach (var iRepo in interfaces)
            {
                var modelName = iRepo.Name.Replace("Repository", "").Replace("I", "");
                var className = $"{modelName}Repository";
                var interfaceName = iRepo.Name;
                var namespaceName = "Infrastructure.Repositories";
                var sb = new StringBuilder();

                // 1. Usings
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Threading;");
                sb.AppendLine("using System.Threading.Tasks;");
                sb.AppendLine("using System.Collections.Generic;");
                sb.AppendLine("using AutoMapper;");
                sb.AppendLine("using Domain.IRepositories;");
                sb.AppendLine("using Domain.Entity;");
                sb.AppendLine("using Shared.Interfaces;");
                sb.AppendLine("using Shared.Wrapper;");
         
                sb.AppendLine();

                // 2. Namespace + Class declaration
                sb.AppendLine($"namespace {namespaceName}");
                sb.AppendLine("{");
                sb.AppendLine($"\tpublic partial class {className} : {interfaceName}");
                sb.AppendLine("\t{");

                // 3. Fields
                sb.AppendLine($"\t\tprivate readonly I{modelName}ApiClient _apiClient;");
                sb.AppendLine("\t\tprivate readonly IMapper _mapper;");
                sb.AppendLine();

                // 4. Constructor
                sb.AppendLine($"\t\tpublic {className}(I{modelName}ApiClient apiClient, IMapper mapper)");
                sb.AppendLine("\t\t{");
                sb.AppendLine("\t\t\t_apiClient = apiClient;");
                sb.AppendLine("\t\t\t_mapper = mapper;");
                sb.AppendLine("\t\t}");
                sb.AppendLine();

                // 5. Implement Methods from Interface
                var methods = iRepo.GetMethods();
                var partialMethods = "";
                foreach (var method in methods)
                {
                    var attributes = method.GetCustomAttributes();

                    var methodSyntax = GeneratorHelpers.ConvertToSyntax(method);
                    (var returnType, var Modifiers) = AutoCodeGenerator.CleanMethodSignature(methodSyntax);
                    //returnType= returnType.Replace("`1[","<").Replace("]", ">");
                    var methodName = method.Name;
                    var parameters = method.GetParameters();
                
                    var paramList = string.Join(",", parameters.Select(p => $"{p.ParameterType.Name} {p.Name}"));
                    var variabels = string.Join(",", parameters.Select(p => $"{p.Name}"));
                    //var variabelsObject = string.Join(",", parameters.Where(p=> p.GetType().IsClass || p.GetType().IsAbstract || p.GetType().IsInterface).Select(p =>  $"{p.Name}"));
                    var variablesObject =parameters.Where(p => p.ParameterType.IsClass && !p.ParameterType.IsPrimitive && p.ParameterType != typeof(string))
                        .Select(p => p.Name);

                    var defaultBody = $"\t\t\t";

                    partialMethods += $"\n\t\tpublic partial  {returnType} On{methodName}({paramList});";

                    sb.AppendLine($"\t\tpublic  {returnType} {methodName}({paramList})");
                    sb.AppendLine("\t\t{");
                    //sb.AppendLine($"\t\t On{methodName}({paramList})");
                    sb.AppendLine(defaultBody);
                    sb.AppendLine("\t\t\tthrow new NotImplementedException();");
                    sb.AppendLine("\t\t}");
                    //sb.AppendLine($"\t\tpublic partial {returnType} On{methodName}({paramList});");
                    sb.AppendLine();
                }

                // 6. Close class + namespace
                sb.AppendLine(partialMethods);
                sb.AppendLine("\t}");
                sb.AppendLine("}");

                // 7. Save to file
                await GeneratorManager.SaveToFileAsync(
                    @$"{dist_root}\\Repositories\\{modelName}\\{className}.cs",
                    sb.ToString()
                );
            }
        }

    }
}
